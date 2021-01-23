    protected void Button1_Click(object sender, EventArgs e)
        {
            //Get path from web.config file to upload
            string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            bool blSucces = false;
            string filename = string.Empty;
            string pathname = string.Empty;
            string filePathName = string.Empty;
    
            //To access the file upload control
            //First get the clicked button
            Button btn = (Button)sender;
    
            //Then get the detailsview row
            DetailsViewRow drv = (DetailsViewRow)btn.Parent.Parent;
    
            //Now you can access the FileUpload control
            FileUpload FileEditUpload1 = (FileUpload)drv.FindControl("FileEditUpload1");
            if (FileEditUpload1.HasFile)
            {
                //Do the rest of your code
            }
        }
