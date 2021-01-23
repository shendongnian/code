    public ObservableCollection<Table1> ReadTable1()
    {            
        using (YourDBContext dc = new YourDBContext())
        {
            var data = (from x in dc.Table1 
                        select x);
             
            return new ObservableCollection<Table1>(data);
        }            
    }
