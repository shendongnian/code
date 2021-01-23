    private double var1;
    public double Var1
    {
        get { return var1; }
        set 
        { 
            var1 = value;
            OnPropertyChanged("Var1"); 
        }
    }
    private double var2;
    public double Var2
    {
        get { return var2; }
        set 
        { 
            var2 = value; 
            OnPropertyChanged("Var2"); 
        }
    }
