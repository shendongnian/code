    if (e.CommandName == "Grab")
    {
          GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
          if (row != null)
          {
              Label2.Text = row.Cells[2].Text;
              Label3.Text = row.Cells[3].Text;
              Label4.Text = row.Cells[4].Text;
              Label5.Text = row.Cells[5].Text;
          }
    }
