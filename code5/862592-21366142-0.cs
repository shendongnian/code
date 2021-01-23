        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                SaveFile(FileUpload1.PostedFile);
            }
            else
            {
                Label4.Text = "You did not specify a file to upload";
            }
        }
        void SaveFile(HttpPostedFile File)
        {
            string savePath = Server.MapPath("~/Images2/");
            string fileName = FileUpload1.FileName;
            string pathToCheck = savePath + fileName;
            string tempFileName = "";
    
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    tempFileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempFileName;
                    counter++;
                }
    
                fileName = tempFileName;
    
                // notify user that file name was changed
                Label4.Text = "A file name with the same name already exist, " +
                    "<br />Your file was saved as " + fileName;
            }
            else
            {
                labelFileName.Text = fileName;
                LabelFileType.Text = FileUpload1.PostedFile.ContentType;
                LabelFileContentLength.Text = FileUpload1.PostedFile.ContentLength.ToString();
                Label4.Text = "Your file was uploaded successfully";
            }
    
            // Append the name of the file to upload to the path
            savePath += fileName;
    
            FileUpload1.SaveAs(savePath);
    
        }
    }
