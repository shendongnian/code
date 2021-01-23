    protected void txtintroId_TextChanged(object sender, EventArgs e)
        {
    float total= 0;
            foreach (GridViewRow gridViewRow in gridView.Rows)
            {
               
                lbltotal = (Label)gridViewRow.FindControl("lbltotal");
              
                float rowValue = 0;
                if (float.TryParse(lbltotal.Text.Trim(), out rowValue))
                    total += rowValue;
            }
            GridView1.FooterRow.Cells[3].Text = total.ToString();
        }
