        public string Error
        {
            get { return PerformValidation(string.Empty); }
        }
        public virtual string this[string propertyName]
        {
            get
            {
                return PerformValidation(propertyName);
            }
        }
