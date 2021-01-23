    public void updateSelectedItemGrid(object Parameter)
    {
        if (Parameter == null) return;
        
        var parameter = Parameter as Test.SharedLib.Data.testSubBO;
        if (parameter == null) return;
        var computerid = Convert.ToInt64(parameter.ComputerId);
        var item = ComputerDataGridListTest.FirstOrDefault(x => x.ComputerId == computerid);
            
        if(item != null)
            item.Term = paramter.Term;
        
    }
