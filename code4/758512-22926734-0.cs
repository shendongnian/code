    List<Table1> TestCollection = new List<Table1>();
    
    public void BindData()
    {
         TestCollection = MyDataEntities.Table1.Where(x=>x.OnLIst == true).ToList();
         DataGrid.ItemsSource = TestCollection;
    }
