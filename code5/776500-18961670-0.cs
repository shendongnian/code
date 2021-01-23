    void GVR_RowDataBound(Object sender, GridViewRowEventArgs e)
      {    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
           string CellContent1 = TC.Text;                        
            DropDownList DDL = new DropDownList();                        
            foreach (object s in Enum.GetValues(typeof(Ticket_Status))) 
            {
                DDL.Items.Add(s.ToString());
            }
            DDL.SelectedValue = CellContent1;
            DDL.ID = "I_Status_CB";    
    e.Row.Cells[2].Controls.Add(DDL);    
                
        }    
      }
