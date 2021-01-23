          // Tried many different encodings here as well, including text/csv
       System.Web.Mvc.FileContentResult file = new System.Web.Mvc.FileContentResult(bytes,
     "text/csv"); // or what you recieve from arguments
                file.FileDownloadName = fileName;
                return file;
