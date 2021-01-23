    DataTable myTable = new DataTable();
    private void Save()
    {
        DataSet myDataSet = new DataSet();
        myDataSet.Tables.Add(myTable);
        myDataSet.Tables.Remove(myTable);//This works
        myDataSet.WriteXml("myTable.xml");
    }
    private void buttonSave_Click(object sender, EventArgs e)
            {
              Save();
            }
