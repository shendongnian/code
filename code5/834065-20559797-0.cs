    protected void btnUpload_Click(object sender, EventArgs e)
    {     
        if (fuFileUploader.HasFile && fuFileUploader.PostedFile.ContentLength > 0)
        {
            string path_file_name = fuFileUploader.PostedFile.FileName;
            string ext = Path.GetExtension(path_file_name).Replace(".", "");
            string file_name = Path.GetFileNameWithoutExtension(path_file_name);
            string file_title = txtFileTitle.Text.Trim();
            HelperDataClassesDataContext db = new HelperDataClassesDataContext();
    
            try
            {
                byte[] file_byte = fuFileUploader.FileBytes;
                Linq.Binary file_binary = new Linq.Binary(file_byte);
    
                ControlDocument cd = new ControlDocument
                {
                    guid = Guid.NewGuid(),
                    file_ext = ext,
                    file_nm = file_name.Trim(),
                    file_title=file_title,
                    file_bin = file_binary,
                    is_active = true,
                    upload_page_type = rblLocation.SelectedValue,
                    upload_dt = DateTime.Now,
                    upload_by = UtilUniverse.Common.CurrentUserLogin.Trim()
                };
    
                db.ControlDocuments.InsertOnSubmit(cd);
            }
            finally
            {
    
                db.SubmitChanges();
            }
        }
    
    }
