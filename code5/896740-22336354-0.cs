        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable mytable = new DataTable(" Class Name ");
            mytable.Columns.Add(new DataColumn(" Class Name ", typeof(string)));
            mytable.Columns.Add(new DataColumn("# Method ", typeof(string)));
            mytable.Columns.Add(new DataColumn("# lines ", typeof(int)));
            // Use your own logic to fill the table with data
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = mytable.NewRow();
                dr[" Class Name "] = "class" + i;
                dr["# Method "] = "";
                dr["# lines "] = i;
                mytable.Rows.Add(dr);
            }
            dataGridView1.DataSource = mytable;
        }
