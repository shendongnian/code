        [HttpPost]
        public void UploadCsv()
        {
            var listOfObjects = new List<ObjectModel>();
            var FileUpload = Request.Files[0]; //Uploaded file
            //check we have a file
            if (FileUpload.ContentLength > 0)
            {
                //Workout our file path
                string fileName = Path.GetFileName(FileUpload.FileName);
                string path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                //Try and upload
                try
                {
                    //save the file
                    FileUpload.SaveAs(path);
                    var sr = new StreamReader(FileUpload.InputStream);
                    string csvData = sr.ReadToEnd();
                    foreach (string r in csvData.Split('\n').Skip(1))
                    {
                        var row = r;
                        if (!string.IsNullOrEmpty(row))
                        {
                            //do something with your data
                            var dataArray = row.Split(',');
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Catch errors
                    //log an error
                }
            }
            else
            {
                //log an error
            }
        }
