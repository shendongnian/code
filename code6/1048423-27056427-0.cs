            DataTable dtcheck = new DataTable();
            dtcheck.Columns.Add("ID");
            dtcheck.Columns.Add("Name");
            for (int i = 0; i <= 15; i++)
            {
                dtcheck.Rows.Add(i, "A" + i);
            }
           
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = dtcheck;
            
        }
    }
        private void button1_Click(object sender, EventArgs e)
        {
           
            string MessageText = string.Empty;
           
            foreach(object item in comboBox1.Items)
            {
               DataRowView row = item as DataRowView;
               MessageText += row["Name"].ToString() + "\n";
            }
            MessageBox.Show(MessageText, "ListItems", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
