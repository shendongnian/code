    gv.AllowPaging = false;
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
                Response.ContentType = "application/zip";
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                gv.RenderControl(htw);
               // byte[] toBytes = Encoding.ASCII.GetBytes(somestring);
                MemoryStream stream = new MemoryStream();
                 string attachment = sw.ToString();
                 byte[] data = Encoding.ASCII.GetBytes(attachment);
                    stream.Write(data, 0, data.Length);
                    stream.Seek(0, SeekOrigin.Begin);   // <-- must do this after writing the stream!
               //   File.WriteAllBytes(@"D:\Saurabh\Testing\inputpdf\saurabhhtest.xls", stream.GetBuffer());
            
           
            using (ZipFile zipFile = new ZipFile())
            {
                zipFile.AddEntry("saurabhtest1.xls", stream);
                zipFile.Save(Response.OutputStream);
            }
