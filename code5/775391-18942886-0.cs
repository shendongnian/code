    public Form1()
    {
        InitializeComponent();
    
        DynamicTypeDescriptor dt = new DynamicTypeDescriptor(typeof(Question));
    
        Question q = new Question(); // initialize question the way you want    
        if (q.Element == 0)
        {
            dt.RemoveProperty("Element");
        }
        propertyGrid1.SelectedObject = dt.FromComponent(q);
    }
