    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName =="edit")
            {
                int i = Convert.ToInt32(e.CommandArgument);
                YourTextBox1.Text = GridView1.Rows[i].Cells[0].Text;
                YourTextBox2.Text = GridView1.Rows[i].Cells[1].Text;
                
            }
        }
