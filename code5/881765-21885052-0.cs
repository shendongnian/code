        public class Test
        {
            private List<string> _myList;
            public Test()
            {
                _myList = new List<string>();
            }
            public List<string> MyList
            {
                get { return _myList; }
            }
            public void ManipulateList()
            {
                _myList.Add("string 1");
                _myList.Add("string 2");
            }
        }
