        public bool Locked { get; set; }
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if(!this.Locked)
                    this.name = val;
            }
        }
    }
