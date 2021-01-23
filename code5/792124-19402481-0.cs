    MyDataObj editItem=null;
    public AddEditForm()
    {      
       InitializeComponent();
       //Other common code for initialization.
    }
    public AddEditForm(MyDataObj obj) : this()
    {      
        editItem = obj;
        //Other code specific to editing.
    }
