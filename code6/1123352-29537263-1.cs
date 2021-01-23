    private string family;
        public string Family
        {
            get { return family; }
            set
            {
                if (family != value)
                {
                    PropertyChangingEventArgs e = new PropertyChangingEventArgs("Family", family, value);
                    OnPropertyChanging(e);
                    family = value;
                    OnPropertyChanged("Family");
                }
            }
        }
