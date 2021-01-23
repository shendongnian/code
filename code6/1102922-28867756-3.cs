    for(int i=0; i<dataGridView1.Rows.Count; i++)
    {
      //* access each row, specif cell
      string lastName	       = dataGridView1.Rows[i].Cell[0].Value;
      string firstName	   = dataGridView1.Rows[i].Cell[1].Value;
      string email		   = dataGridView1.Rows[i].Cell[2].Value;
      string phoneNumber	   = dataGridView1.Rows[i].Cell[3].Value;
      string address		   = dataGridView1.Rows[i].Cell[4].Value;
      string instagram	   = dataGridView1.Rows[i].Cell[5].Value;
      string carMake		   = dataGridView1.Rows[i].Cell[6].Value;
      string carModel		   = dataGridView1.Rows[i].Cell[7].Value;
      string additionalNotes = dataGridView1.Rows[i].Cell[8].Value;
    }
