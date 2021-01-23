    public CustomerForm()
    {
       InitializeComponents();
       .. to do new object
    }
    
    public CustomerForm(MyDataObj obj)
    :CustomerForm()
    {      
       SetFormData(obj);
    }
    
    public void SetFormData(MyDataObj obj)
    {      
       ... to do edit
    }
    
    public bool EnableEdit {get{... 
