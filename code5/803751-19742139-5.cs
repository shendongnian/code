        protected void WriteFile(HttpResponseBase response)
        {
            // Add the header and the content type required for this view.
            string format = string.Format("attachment; filename={0}", "somefile.csv");
            response.AddHeader("Content-Disposition", format);
            response.ContentType = "text/csv"; //if you use base.ContentType, 
            //please make sure this return the "text/csv" during test execution.
            // Gets the current output stream.
            var outputStream = response.OutputStream;
            // Create a new memorystream.
            using (var memoryStream = new MemoryStream())
            {
                // WriteDataTable(memoryStream);
                outputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
        }
