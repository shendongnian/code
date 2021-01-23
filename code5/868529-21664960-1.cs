    protected void DistrictList_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            FileUpload Fupload = (FileUpload)DistrictList.InsertItem.FindControl("FileUploadDistrictInsert");
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
                    case ".JPG":
                        ContentType = "Image/jpg";
                        break;
                    case ".jpeg":
                        ContentType = "Image/jpeg";
                        break;
                    case ".JPEG":
                        ContentType = "Image/jpeg";
                        break;
                    case ".png":
                        ContentType = "Image/png";
                        break;
                    case ".PNG":
                        ContentType = "Image/png";
                        break;
                    case ".bmp":
                        ContentType = "Image/bmp";
                        break;
                    case ".BMP":
                        ContentType = "Image/bmp";
                        break;
                }
                if (ContentType != String.Empty)
                {
                    Stream FileStream = Fupload.PostedFile.InputStream;
                    BinaryReader FileReader = new BinaryReader(FileStream);
                    Byte[] bytes = FileReader.ReadBytes((Int32)FileStream.Length);
                    string disID = e.Values["DistrictName"].ToString();
                    //insert the file into database
                    using (Entity.MedicalEntities emp = new Entity.MedicalEntities())
                    {
                        Entity.District districts = (from h in emp.Districts where h.DistrictName == disID select h).First();
                        districts.DistrictImage = bytes;
                        emp.SaveChanges();
                    }
                }
            }
        }
