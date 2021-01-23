    private TestEnum enumInstance = TestEnum.None;
    public TestEnum EnumInstance
    {
        get { return enumInstance; }
        set { enumInstance = value; NotifyPropertyChanged("EnumInstance"); }
    }
    private ObservableCollection<TestEnum> enumCollection = 
        new ObservableCollection<TestEnum>() { TestEnum.None, TestEnum.One, 
        TestEnum.Two, TestEnum.Three };
    public ObservableCollection<TestEnum> EnumCollection
    {
        get { return enumCollection; }
        set { enumCollection = value; NotifyPropertyChanged("EnumCollection"); }
    }
