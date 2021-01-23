                string filepath ="/Interface/AdminUploads/Miscellaneous/FILENAME"; // Full Path of Pdf.
                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(filepath);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
                Response.Flush();
                Response.End();
