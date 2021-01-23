    public Dictionary<MyEnum, string> Dict
    {
        get { return EnumExtension.EnumToDictionary<MyEnum>(); }
    }
    private MyEnum _selectedValue;
    public MyEnum SelectedValue
    {
        get { return _selectedValue; }
        set
        {
            _selectedValue= value;
            RaisePropertyChanged(() => Reg(() => SelectedValue));
        }
    }
