    foreach (Class1 aa in ds) 
         {
            checkedListBox1.Items.Add(aa.id + "_" + aa.shape + "_" + aa.color);
                  DataTable dt = new DataTable();
                  dt.Columns.Add("Shape");
                  dt.Columns.Add("Colour");
                  for (int i = 0; i < ds.Count; i++)
                  {
                      DataRow dRow = dt.NewRow();
                      dRow["Shape"] = aa.shape;
                      dRow["Colour"] = aa.color;
                      dt.Rows.Add(dRow);
                 }
                 dataGridView1.DataSource = dt; 
                 dataGridView1.Refresh();
        }
    }
