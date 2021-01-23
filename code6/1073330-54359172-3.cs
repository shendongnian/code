    public object SaveCertificateSettings()
        {
            string Name = Convert.ToString(HttpContext.Current.Request.Form["Name"]);
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["TemplatePath"];
                if (httpPostedFile != null)
                {
                    // httpPostedFile.FileName;
                    // Get the complete file path
                    
                }
            }
		}
