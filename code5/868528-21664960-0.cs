            protected void DistrictList_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            FileUpload Fupload = (FileUpload)DistrictList.EditItem.FindControl("FileUploadDistrictEdit");
            if (Fupload.HasFile)
            {
                string FilePath = Fupload.PostedFile.FileName;
                string FileName = Path.GetFileName(FilePath);
                string Ext = Path.GetExtension(FileName);
                string ContentType = String.Empty;
                switch (Ext)
                {
                    case ".jpg":
                        ContentType = "Image/jpg";
                        break;
                    case ".jpeg":
                        ContentType = "Image/jpeg";
                        break;
                    case ".png":
                        ContentType = "Image/png";
                        break;
                    case ".bmp":
                        ContentType = "Image/bmp";
                        break;
                }
                if (ContentType != String.Empty)
                {
                    Stream FileStream = Fupload.PostedFile.InputStream;
                    BinaryReader FileReader = new BinaryReader(FileStream);
                    Byte[] bytes = FileReader.ReadBytes((Int32)FileStream.Length);
 
                    string disName = e.NewValues["DistrictName"].ToString(); 
                    //insert the file into database
                    using (Entity.MedicalEntities emp = new Entity.MedicalEntities())
                    {
                        Entity.District districts = (from h in emp.Districts where h.DistrictName == disName select h).First();
                        districts.DistrictImage = bytes;
                        emp.SaveChanges();
                    }
                }
            }
        }
