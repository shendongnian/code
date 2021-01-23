    public void CalculateAandB()
    {
        PropertyA = 12m;
        PropertyB = 14m;
    
        PropertyChanged(this, new PropertyChangedEventArgs("PropertyA"));
        PropertyChanged(this, new PropertyChangedEventArgs("PropertyB"));
    }
