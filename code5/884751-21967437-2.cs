    class Element
    {
        protected int _idx;  
        protected string _name; 
        public int Idx { get { return _idx; } }
        public string Name { get { return _name; } }
        public Element(int idx, string name)
        {
          _idx = idx;   
          _name = name;
        }
    }
