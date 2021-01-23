     [HttpPost]
            public KeyValuePair<bool, string> UploadFile()
            {
                try
                {
                    if (HttpContext.Current.Request.Files.AllKeys.Any())
                    {
                        // Get the uploaded image from the Files collection
                        var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                        if (httpPostedFile != null)
                        {
                            // Validate the uploaded image(optional)
                            // Get the complete file path
                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/UploadedFiles"), httpPostedFile.FileName);
                            // Save the uploaded file to "UploadedFiles" folder
                            httpPostedFile.SaveAs(fileSavePath);
                            return new KeyValuePair<bool, string>(true, "File uploaded successfully.");
                        }
                        return new KeyValuePair<bool, string>(true, "Could not get the uploaded file.");
                    }
                    return new KeyValuePair<bool, string>(true, "No file found to upload.");
                }
                catch (Exception ex)
                {
                    return new KeyValuePair<bool, string>(false, "An error occurred while uploading the file. Error Message: " + ex.Message);
                }
            }
