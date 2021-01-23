    public class MyClass
    {
        public IEnumerable<string> _MyData = null;
        public IEnumerable<string> _dbContext = new List<string> {"a", "b", "aa", "bb"};
        public MyClass(){}
        public MyClass(string parm1, int parm2){Load(parm1, parm2);}
    
        public void Load(string parm1, int parm2)
        {
            var somedata = _dbContext.Where(m => m.Length == 2).ToList();
    
            var myData = somedata.Select(s => s == parm1 ? "something else" : s).ToList();
    
            _MyData = myData;
        }
    }
