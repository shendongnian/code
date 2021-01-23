    private string _sex;
    public string Sex
    {
        get { return _sex; }
        set
        {
            if (_sex != value)
            {
                _sex = value;
                OnPropertyChanged("Sex");
            }
        }
    }
    private void WhateverMethodYouHaveGettingDataFromDB()
    {
        //... do whatever it needs ...
        Sex = // get sex from database...
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
