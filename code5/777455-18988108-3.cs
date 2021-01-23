    public void Bar
    {
        private Dictionary<string, string> values = 
             context.Foos.ToDictionary(f => f.Key, f => f.Value);
        public string Name { get { return values["Name"]; } }
        public string Surname { get { return values["Surname"]; } }
    }
