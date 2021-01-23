     private void FormView_Load(object sender, EventArgs e)
      {
    	sample = new DataTable(); //Sample Data
                sample.Columns.Add("id", typeof(string));
                sample.Columns.Add("name", typeof(string));
                sample.Rows.Add("1", "apple");
                sample.Rows.Add("2", "acer");
                sample.Rows.Add("3", "alpha");
                sample.Rows.Add("4", "beat");
                sample.Rows.Add("5", "ball");
                sample.Rows.Add("6", "cat");
                sample.Rows.Add("7", "catch");
                sample.Rows.Add("10", "zebra");
    
                listViewEx1.View = View.Details;
                listViewEx1.Columns.Add("id");
                listViewEx1.Columns.Add("name");
      }
    
    
    
    	     listViewEx1.Items.Clear();
    
                listViewEx1.FullRowSelect = true;
    
                foreach (DataRow row in sample.Rows)
                {
                        ListViewItem item = new ListViewItem(row["id"].ToString());
                        item.SubItems.Add(row["name"].ToString());
                        listViewEx1.Items.Add(item); //Add this row to the ListView
                 }
