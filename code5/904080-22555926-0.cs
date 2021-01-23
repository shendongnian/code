    if ((row.FindControl("CheckBox1") as CheckBox).Checked)
            {
                DataRow dr = dt.NewRow();
                dt[0] = TextBox1.Text; 
                dt[1] = TextBox2.Text; 
                dt[2] = TextBox3.Text;
                dt.Rows.Add(NewRow); 
            }
