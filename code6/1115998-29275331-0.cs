    string command = "SELECT * FROM [table] ORDER BY [column]";
    //database connection string
    string constring =[database connection string];
    //open DB connection - execute query - create dataadapter - fill datatable - bind datasource to datatable
    using (SqlConnection con = new SqlConnection(constring))
        {
        using (SqlCommand cmd = new SqlCommand(command, con))
            {
            cmd.CommandType = CommandType.Text;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                using (DataTable dt = new DataTable())
                    {
                    try
                      {
                      //fill the dataGridView
                      sda.Fill(dt);
                      dataGridView1.DataSource = dt;
                      Console.WriteLine("Refreshing Complete");
                      //disable manual sorting on all columns
                      for (int i = 0; i < dataGridView1.Columns.Count; i++)
                      {
                        dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                      }
                      //Autosize all cells
                      dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                      dataGridView1.AutoResizeColumns();
                      }
                      catch (Exception e)
                      {
                      MessageBox.Show(e.Message);
                      }
                  }
              }
           }
      }
      
