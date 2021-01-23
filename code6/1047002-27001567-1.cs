    class Okay : IYes
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null) throw new ArgumentNullException("Name");
                if (value.Length < 3 || value.Length > 10) 
                    throw new ArgumentOutOfRangeException("Name");
                name = value;
            }
        }
    }
