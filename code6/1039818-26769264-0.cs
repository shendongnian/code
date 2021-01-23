       private string[] z_multiChoiceOptions = null;
        public string[] multiChoiceOptions
        {
            get
            {
                return this.z_multiChoiceOptions;
            }
        }
        private string z_Options = null;
        public string Options
        {
            get { return z_Options; }
            set { 
                z_Options = value;
                if (value != null)
                    this.z_multiChoiceOptions = Regex.Split(value, "\r\n");
                else
                    this.z_multiChoiceOptions = null;
            }
        }
