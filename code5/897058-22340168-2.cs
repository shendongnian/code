    public void updateSelectedItemGrid(Test.SharedLib.Data.testSubBO parameter)
    {
        if (parameter == null) return;
        var item = ComputerDataGridListTest.FirstOrDefault(x => x.ComputerId == parameter.computerid);
            
        if(item != null)
            item.Term = paramter.Term;
        
    }
