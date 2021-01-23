    private string output;
    public string Output
    {
        get { return output; }
        set
        {
            if (output != value)
            {
                output = value;
                OnPropertyChanged("Output");
            }
        }
    }
