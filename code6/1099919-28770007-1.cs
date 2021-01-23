    private void LoadGrid()
    {
        //Creating the list of records
        MyRecords.Add(new MyRecord { Checked = false, EndsPerInch = 92});
        MyRecords.Add(new MyRecord { Checked = false, EndsPerInch = 56 });
        MyRecords.Add(new MyRecord { Checked = false, EndsPerInch = 100 });
    
        //Binding the list of records to the datagridview
        //By doing so, a checkbox column will automatically be generated and bound
        //to the "Checked" property of your class
        dataGridView1.DataSource = MyRecords;
    }
