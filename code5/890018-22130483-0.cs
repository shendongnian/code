    public List<ComputerDataGridBO> ItemsToSave { get; set; }
    public void AddSelectedItemGrid(object Parameter)
    {
        if (Parameter != null)
        {
            string test1 = ((Test.SharedLib.Data.testSubBO)(Parameter)).Term;
            Int64 test2 = Convert.ToInt64(((testSubBO)(Parameter)).ComputerId);
            ComputerDataGridBO newItem = new ComputerDataGridBO()
            {
                Term = test1,
                ComputerId = test2
            };
            ItemsToSave.Add(newItem);
            ComputerDataGridListTest.Add(newItem);
        }
    }
