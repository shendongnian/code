    protected void BtnuploadClick(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/") + filename);
    
                var application = new Application();
                var document = application.Documents.Open(Server.MapPath("~/") + filename);
    
                // Get the page count.
                var numberOfPages = document.ComputeStatistics(WdStatistic.wdStatisticPages, false);
    
                StatusLabel.Text = string.Format("Total number of pages in document: {0}", numberOfPages);
    
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    
    }
