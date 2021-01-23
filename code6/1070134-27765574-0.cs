    private List<string> _ItemList = new List<string>();
    
    private string string1selected; 
    private string string2selected;
    
    public IEnemerable<string> ItemList1
    {
       get
       {
           return _ItemList.Where(x => x != String2selected);
       }
    }
    public string String2selected
    {
       get
       {
           return string2selected;
       }
       set 
       {
           if (string2selected == value) return;
           NotifypropertyChanged("String2selected");
           NotifypropertyChanged("ItemList1");
       }
    }
