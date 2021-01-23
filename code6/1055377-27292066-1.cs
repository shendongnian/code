        public string MyValue
        {
            get
            {
                return (Application.Current as MyApp.App).myValue;
            }
            set
            {
                (Application.Current as MyApp.App).myValue= value;
            }
        }
