        void WriteFile(string path, string filename)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                //response is HttpListenerContext.Response... 
                Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Octet;
                Response.AddHeader("Content-disposition", "attachment; filename=" + filename); 
                byte[] buffer = new byte[64 * 1024];
                int read; 
                while ((read = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Response.OutputStream.Write(buffer, 0, read);
                    Response.OutputStream.Flush(); //seems to have no effect
                } 
                Response.OutputStream.Close();
            }
            File.Delete(path);
            Response.End();
        }
