    public double Txt
        {
            get { return txt; }
            set
            {
                if (!txt.Equals(value))
                {
                    
                    txt = value;
                    OnPropertyChanged("Txt");
                }
            }
        }
