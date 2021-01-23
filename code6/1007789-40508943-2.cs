    for (int numberOfCells = 0; numberOfCells < this.dataGridView1.Columns.Count; numberOfCells++)
    {
      if (String.IsNullOrEmpty(this.dataGridView1.Rows[0].Cells[numberOfCells].Value as String))
      {
         //empty
      }
	  else
	  {
	     //not empty
	  }
    }
