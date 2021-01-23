    public double Counter
    { 
        get { ... }
        set 
        {
            if (gnCounter != value)
            {  
                gnCounter = value;
                Delta = (int)((Xmax - Xmin) / (gnCounter  - 1));
                OnPropertyChanged("Counter");
            } 
        }
    }
