    var vm = new { MyString = "Test1" };         // ViewModel
    
    var dt = new DataTable();
    dt.Columns.Add("MyString", typeof(String));
    dt.Rows.Add("Test2");
    var drv = dt.DefaultView[0];                 // DataRowView
    var value1 = TypeDescriptor.GetProperties(vm)["MyString"].GetValue(vm);
    var value2 = TypeDescriptor.GetProperties(drv)["MyString"].GetValue(drv);
    // value1 = "Test1", value2 = "Test2"
