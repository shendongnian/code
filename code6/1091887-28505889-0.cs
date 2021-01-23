    private string prop1 = string.Empty;
    public string Prop1 
    {
        get { return prop1; }
        set 
        {
            if (ValueIsValid(prop1))
            {
                NotifyPropertyChanged("Prop1");
                return;   // or you can throw an exeption 
            }
            if (prop1 == value)  return;
            prop1 = value;
            NotifyPropertyChanged("Prop1");
        }
    }
