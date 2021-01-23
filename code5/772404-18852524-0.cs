    public void addToDataGridView()
    {
    	int index = dataGridView.Rows.Add("test1", fileName, fileSize, DateTime.Now, "myStatus");
    	dataGridView.Rows(index).Cells(4).Style.BackColor = Color.AliceBlue;
    }
