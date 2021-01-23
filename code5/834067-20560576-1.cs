     InstituteRegistration insti = new InstituteRegistration(); 
     if (FileUploadInstituteImage.PostedFile.ContentLength != 0)
            {
                string extension =         System.IO.Path.GetExtension(FileUploadInstituteImage.FileName);
                if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".gif" || extention.ToLower() == ".png" || extention.ToLower() == ".bmp" || extention.ToLower() == ".tif" || extention.ToLower() == ".tiff")
                {
                    Stream fsInstitute = FileUploadInstituteImage.PostedFile.InputStream;
                    BinaryReader brInsti = new BinaryReader(fsInstitute);
                    Byte[] bytesInstitute = brInsti.ReadBytes((Int32)fsInstitute.Length);
                    insti.InstituteImage = bytesInstitute;
                }
                else
                {
                    lblMsg.Text = "Invalid File.";
                    return;
                }
            }
     db.InstituteRegistrations.InsertOnSubmit(insti);
     db.SubmitChanges();
