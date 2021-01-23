If you are binding a List
    //Assume Student list is bound as Dtaasource
    List<Student> student = new List<Student>();
    
    //Add a new student object to the list
    student .Add(new Student());
    
    //Reset the Datasource
    dataGridView1.DataSource = null;
    dataGridView1.DataSource = student;
If you are binding DataTable
    DataTable table = new DataTable();
    
     DataRow newRow = table.NewRow();
    
    // Add the row to the rows collection.
    table.Rows.Add(newRow);
