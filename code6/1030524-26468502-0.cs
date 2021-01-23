    private string _amt;
    
    public string Amount
    {
        get{return _amt;}
        set
        {
             _amt = value; 
            if(AddItem == false)
                AddItem = true;
     
            //PropertyChanges here
        }
    }
