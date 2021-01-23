    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                FileUpload1.SaveAs(Server.MapPath("") + FileUpload1.FileName);
                Label1.Text = "File name: " +
                FileUpload1.PostedFile.FileName + "<br>" +
                FileUpload1.PostedFile.ContentLength + " kb<br>" + "Content type: " +
                 FileUpload1.PostedFile.ContentType + "<br><b>Uploaded Successfully";
            }
            catch (Exception ex)
            {
                Label1.Text = "ERROR: " + ex.Message.ToString();
            }
        }
        else
        {
            Label1.Text = "You have not specified a file.";
        }
        CSVReader reader = new CSVReader(FileUpload1.PostedFile.InputStream);
        string[] headers = reader.GetCSVLine();
        DataTable dt = new DataTable();
        foreach (string strHeader in headers)
        {
            dt.Columns.Add(strHeader);
        }
        
        string[] data;
        while ((data = reader.GetCSVLine()) != null)
        {
            dt.Rows.Add(data);
        }
        // Loop through each row in the data table
        foreach (DataRow row in dt.Rows) 
        {
            // Loop through each column in row
            for (int i = 0; i <= dt.Columns.Count - 1; i++) 
            {
                // Do whatever you want here for each cell
            }
        }
        csvReaderGv.DataSource = dt;
        csvReaderGv.DataBind();
    }
