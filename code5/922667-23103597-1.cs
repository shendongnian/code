    protected void Grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var button = (Button)e.Row.FindControl("btnuploadfiles");
            var fileUpload = (FileUpload)e.Row.FindControl("File1");
            string className = "class_" + new Random().Next();
            button.Attributes.Add("class", "rowClick");
            fileUpload.Attributes.Add("class", "rowClick"); 
            button.Attributes.Add("customClass", className);
            button.Attributes.Add("customClass", className); 
        }
    }
