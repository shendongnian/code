    MyDataObj _myObject;
    public AddEditForm()
    {
        InitializeComponent();
    }
    public AddEditForm(MyDataObj obj)
        :this()
    {      
        if(obj == null)
           _myObject = new MyDataObj();
        else
            _myObject = obj;
    }
    // Continue my work with _myObject
