    public int Delta
        {
            get { return gnDelta; }
            set { gnDelta = value; 
                  OnPropertyChanged("Delta"); 
                  OnPropertyChanged("Counter");}
        }
        public double Counter
        {
            get { return gnCounter; }
            set { gnCounter = value; 
                OnPropertyChanged("Counter");
                OnPropertyChanged("Delta"); }
        }
