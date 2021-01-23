    protected void hoursReportGridView_OnRowDataBound(Object sender, GridViewRowEventArgs e)
    {
           DataRowView rowView = (DataRowView)e.Row.DataItem;
    
           int a = Convert.ToInt32(rowView["DifferentUsers"]);
    
           if(a>0)
            {
        
                for (int i = 0; i < 15; i++)
                {
                    e.Row.Cells[i].ForeColor = Color.Black;
                    e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#fde16d");
                }
            }
        
    }
