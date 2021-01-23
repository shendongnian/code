    List<MyDataClass> lstItems = new List<MyDataClass>();
    lstItems.Add(new MyDataClass("Item 1", 1));
    lstItems.Add(new MyDataClass("Item 2", 2));
    lstItems.Add(new MyDataClass("Item 3", 3));
    
    
    listData.DataSource = lstItems;
    listData.DisplayMember = "Display";
    listData.ValueMember = "Value";
