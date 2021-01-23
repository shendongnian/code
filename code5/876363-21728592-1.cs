     protected void btn_Click(object sender, EventArgs e)
        {
            //clicked button
            LinkButton btn= (LinkButton)sender;
    
            // row of the clicked button
            GridViewRow containerRow = (GridViewRow)(btn).NamingContainer;
        
        Label id = (Label)containerRow .Cells[6].FindControl("lblid");
        Label lblqus = (Label)containerRow .Cells[3].FindControl("Label1"); 
        Label lblans = (Label)containerRow .Cells[4].FindControl("Label2");
    
     /// remaining code
    
    }
