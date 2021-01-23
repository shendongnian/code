    public void GetData()
    {
         var data = Repository.DataQuery<Table2Type>(); 
         var result = data.Select(d => new 
            {
                Value = d.Code,
                Text = d.Name
            });     
    }
