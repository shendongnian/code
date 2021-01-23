            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
            GridViewRow row = GridView1.Rows[i];
            CheckBox Ckbox = (CheckBox)row.FindControl("CheckBox1");
            if (Ckbox.Checked == true)
                 {
                     TextBox1.Text = row.Cells[1].Text; 
                     TextBox2.Text = row.Cells[2].Text; 
                     TextBox3.Text = row.Cells[3].Text; 
                 }
            }
