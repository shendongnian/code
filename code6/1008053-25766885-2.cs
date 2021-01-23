    foreach (DataGridViewColumn column in dataGridView1.Columns)
    {
       if (dataGridView1.Rows[0].Cells[column.Name].Value.GetType() == typeof(System.Drawing.Bitmap)) //Or whatever type you store your image as
       {
          //Do the copy over
       }
    }
