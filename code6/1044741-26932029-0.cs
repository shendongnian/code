    protected void dl_Click(object sender, ImageClickEventArgs e)
    {
        if(Session["MyTable"]==null)
    {
    
        string csv = ToCSV(DataTable(Session["MyTable"]) );  
        Response.ContentType = "application/csv";
        Response.AddHeader("content-disposition", "attachment; filename=file.csv");
        Response.Write(csv);
        Response.End();    
    
    }       
    }
