    public Class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private int _Level;
        public int Level
        { 
          get { return _Level; } 
          set { _Level= value; _hasLevel = true; } 
        }
        public bool HasLevel { get { return _hasLevel; } }
    }
