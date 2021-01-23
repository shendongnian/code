    [Serializable]
    class DOThis
    {
        private string _name;
    
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    
        [NonSerialized()]
        public string Value
        {
            get
            {
                if (_name == "Hi")
                    return "Hey Hi";
                else
                    return "Sorry I dont know you";
            }
        }
    }
