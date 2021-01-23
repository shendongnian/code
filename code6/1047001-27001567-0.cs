    class Okay : IYes
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 3 || value.Length > 10) 
                    throw new ArgumentOutOfRangeException("Name");
                name = value;
            }
        }
    }
