    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    
        if (e.CommandName.ToLower()== "modify") 
        {
            Panel1.Visible = true;
            int index = Convert.ToInt32(e.CommandArgument);       
    
            Label login = (Label)GridView1.Rows[index].Cells[0].FindControl("Label1");
           //Things i want to do 
    
        }
    }
