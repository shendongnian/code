        static void Main()
        {
            var child1 = new List<Dictionary<string, object>>();
            var childOneDic = new Dictionary<string, object> 
    { 
        { "ChildName", "John" }, 
        { "ChildAge", 10 } 
    };
            child1.Add(childOneDic);
            var child2 = new List<Dictionary<string, object>>();
            var childTwoDic = new Dictionary<string, object> 
    { 
        { "ChildName", "Tony" }, 
        { "ChildAge", 12 } 
    };
            child2.Add(childTwoDic);
            var parrent = new List<Dictionary<string, object>>();
            var parrentDic = new Dictionary<string, object>
    {
        { "Name", "Mike" },
        { "LastName", "Tyson" },
        { "child1", child1 },
        { "child2", child2 }
    };
            parrent.Add(parrentDic);
            List<Parent> goodList = new List<Parent>();
            List<Child> allChilds = new List<Child>();
            foreach (Dictionary<string, object> p in parrent)
            {
                Parent newParent = new Parent(p);
                goodList.Add(newParent);
                allChilds.AddRange(newParent.Childs);
            }
            foreach (Child c in allChilds)
            {
                Console.WriteLine(c.ParentName + ":" + c.ParentName + ":" + c.Name + ":" + c.Age);
            }
            Console.ReadLine();
        }
        public class Parent
        {
            private List<Child> _childs = new List<Child>();
            private Dictionary<string, object> _dto;
            public Parent(Dictionary<string, object> dto)
            {
                _dto = dto;
                for (int i = 0; i <= 99; i++)
                {
                    if (_dto.ContainsKey("child" + i))
                    {
                        _childs.Add(new Child(((List<Dictionary<string, object>>)_dto["child" + i])[0], this));
                    }
                }
            }
            public string Name
            {
                get { return (string)_dto["Name"]; }
            }
            public string LastName
            {
                get { return (string)_dto["LastName"]; }
            }
            public List<Child> Childs
            {
                get { return _childs; }
            }
        }
        public class Child
        {
            private Parent _parent;
            private Dictionary<string, object> _dto;
            public Child(Dictionary<string, object> dto, Parent parent)
            {
                _parent = parent;
                _dto = dto;
            }
            public string Name
            {
                get { return (string)_dto["ChildName"]; }
            }
            public int Age
            {
                get { return (int)_dto["ChildAge"]; }
            }
            public string ParentName
            {
                get { return _parent.Name; }
            }
            public string ParentLastName
            {
                get { return _parent.LastName; }
            }
        }
    }
