    clsFileUpload fileUpload = new clsFileUpload();
    dataTable = fileUpload.GetDownloadsFiles(ClsSystemUsers.ProgramId, ClsSystemUsers.SemesterN, 3);
    //rptLec is my repeater id...
    rptLec.DataSource = dataTable;
    rptLec.DataBind();
    for (int i = 0; i < dataTable.Rows.Count; i++)
    {
            string label = dt.Rows[i]["Url"].ToString();
            Image = (Image)rptLec.Items[0].FindControl("Image_Video");      
            if (label != null)
            {
                string turl = label;
                GetYouTubeImage(turl);//function for getting image from youtube
            }
    } 
