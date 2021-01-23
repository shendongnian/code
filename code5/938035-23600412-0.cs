    List<MyClass> list = new List<MyClass>();
    DataTable dt = DataGridView1.DataSource as DataTable;
    foreach (DataRow row in dt.Rows)
    {
        MyClass myObject = new MyClass();
        myObject.id = (int)row["Id"]; // Assuming the column is called "Id"
        myObject.Name = (string)row["Name"];// Assuming the column is called "Name"
        list.Add(myObject);
    }
