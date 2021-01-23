    if ((row.FindControl("CheckBox1") as CheckBox).Checked)
            {
                DataRow dr = dt.NewRow();
                dr[0] = TextBox1.Text; 
                dr[1] = TextBox2.Text; 
                dr[2] = TextBox3.Text;
                dt.Rows.InsertAt(dr,dt.Rows.Count);
            }
