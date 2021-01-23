    private FamilyModel data;
    public string Name
    {
        get { return data.Name; }
        set { data.Name = value; OnPropertyChanged("Name"); }
    }
    public string Location
    {
        get { return data.Location; }
        set { data.Location = value; OnPropertyChanged("Location"); }
    }
