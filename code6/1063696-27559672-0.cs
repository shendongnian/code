    class Program
    {
        static void Main(string[] args)  
        {
            bool needChild = true;
            IEnumerable<IMyClass> myChildList = GetSomeValue("1", needChild);
            List<Child> myChildren = myChildList.Cast<Child>().ToList();
            needChild = false;
            IEnumerable<IMyClass> myParentList = GetSomeValue("1", needChild);
            List<Parent> myParents = myParentList.Cast<Parent>().ToList();
        }
        private static IEnumerable<IMyClass> GetSomeValue(string id, bool needChild)
        {
            if (needChild)
            {
                return BuildChildResult(id);
            }
            return BuildParentResult(id);
        }
        private static IEnumerable<IMyClass> BuildChildResult(string id)
        {
            var list = new List<IMyClass>
            {
                new Child {ChildName = "Test 1", Id = "1"},
                new Child {ChildName = "Test 2", Id = "1"},
                new Child {ChildName = "Test 3", Id = "1"},
                new Child {ChildName = "Test 4", Id = "2"},
                new Child {ChildName = "Test 4", Id = "2"},
                new Child {ChildName = "Test 4", Id = "3"}
            };
            return list.Where(z => z.Id == id).ToList();
        }
        private static IEnumerable<IMyClass> BuildParentResult(string id)
        {
            var list = new List<IMyClass>
            {
                new Parent {ParentName = "Test 1", Id = "1"},
                new Parent {ParentName = "Test 2", Id = "1"},
                new Parent {ParentName = "Test 3", Id = "1"},
                new Parent {ParentName = "Test 4", Id = "2"},
                new Parent {ParentName = "Test 4", Id = "2"},
                new Parent {ParentName = "Test 4", Id = "3"}
            };
            return list.Where(z => z.Id == id).ToList();
        }
    }
    public interface IMyClass
    {
        string Id { get; set; }
        bool IsParent { get; set; }
    }
    public class Parent : IMyClass
    {
        public string Id { get; set; }
        public bool IsParent { get; set; }
        public string ParentName { get; set; }
        public Parent()
        {
            IsParent = true;
        }
    }
    public class Child : IMyClass
    {
        public string Id { get; set; }
        public bool IsParent { get; set; }
        public string ChildName { get; set; }
        public Child()
        {
            IsParent = false;
        }
    }
