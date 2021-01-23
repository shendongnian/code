    MyDataObj _myObject;
    public AddEditForm()
    {
        InitializeComponent();
    }
    public AddEditForm(MyDataObj obj)
        :this()
    {      
        if(obj == null) //you're creating the object
           _myObject = new MyDataObj();
        else // you're editing it
            _myObject = obj;
    }
    // Continue my work with _myObject
