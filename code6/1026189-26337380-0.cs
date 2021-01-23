            Response.ContentType = "application/zip";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Test.zip")
            Response.TransmitFile(@"C:\Test.zip");
            Response.Flush();
            // Prevents any other content from being sent to the browser
            Response.SuppressContent = true;
            // Directs the thread to finish, bypassing additional processing
            HttpContext.Current.ApplicationInstance.CompleteRequest();
