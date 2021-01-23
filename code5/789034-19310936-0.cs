    public class MyClass
    {
        private List<string> _myClassMember = null;
        public MyClass()
        {
            _myClassMember = new List<string>();
        }
        public IReadOnlyList<string> GetClassMembers()
        {
            return _myClassMember.AsReadOnly();
        }
        public void PrintMembers()
        {
            Console.WriteLine("No of items in member {0}", _myClassMember.Count.ToString());
        }
    }
