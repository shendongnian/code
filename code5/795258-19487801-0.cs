            string filename = Path.GetFileName(FileUpload1.FileName);
            HttpFileCollection MyFileCollection = HttpContext.Current.Request.Files;
            if (MyFileCollection.Count > 0)
            {
                try
                {
                    MyFileCollection[0].SaveAs(Server.MapPath("~/ProductVideos/") + filename);
                    
                 }
                catch (Exception ex)
                {
                    
                }
            }
