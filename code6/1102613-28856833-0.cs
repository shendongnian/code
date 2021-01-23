    private string _name;
    public string Name
    {
        get { return this._name; }
        set
        {
            if (this._name != value)
            {
                this._name = value;
                this.OnPropertyChanged(); //no argument passed
            }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberNameAttribute]string propertyName = "")
    { //propertyName will be set to "Name"
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
