        DataTable dataTable = new DataTable("myData");
        dataTable.Columns.Add("numericData", typeof(int)); // this will make sure datagrid is sorting as numeric
        dataTable.Columns.Add("stringData", typeof(String));
        dataTable.Columns.Add("anotherNumericData", typeof(decimal));
        // rest of your code...
        datagrid1.ItemsSource = dataTable.DefaultView;
