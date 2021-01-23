      protected void lnkEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            
            txt1.Text = row.Cells[0].Text;
            txt2.Text = row.Cells[1].Text;
        }
