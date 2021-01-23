    public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }
        public string Error { get; private set; }
        public string Validate(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Value":
                    if (_value.Length != 17)
                        error = "Invalid value";
                    break;
            }
            Error = error;
            return error;
        }
