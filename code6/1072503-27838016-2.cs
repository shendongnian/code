    class Self
    {
        public string Name { get; }
        public Self([CallerMemberName] string name = null)
        {
            this.Name = name;
        }
    }
