    List<MyClass> list = new List<MyClass>();
    foreach (DataGridViewRow row in DataGridView1.Rows)
    {
        MyClass myObject = new MyClass();
        myObject.id = (int)row.Cells["Id"].Value; // Assuming the column is called "Id"
        myObject.Name = (string)row.Cells["Name"].Value;// Assuming the column is called "Name"
        list.Add(myObject);
    }
