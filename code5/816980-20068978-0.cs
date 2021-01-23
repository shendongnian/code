         //SignalR
             string zipName = "myZip"
             Clients.All.pushFileNotification("Download.aspx?myZip=" + zipName);
         
         //Download.aspx
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request["myZip"]))
            {
                download(Request["myZip"]);
            }
         }
        private void download(string myZip)
        {
            Response.Clear();
            if (myZip == "myZip") // some validation if you want
            {                
                using (MemoryStream output = new MemoryStream())
                {
                    using (var zip = new ZipFile())
                    {
                        zip.AddDirectory(mydir);
                        if (Response.IsClientConnected)
                        {
                            Response.ClearHeaders();
                            Response.ClearContent();
                            zip.Save(output);
                            byte[] buffer = output.ToArray();
                            Response.AppendHeader("Content-Length", buffer.Length.ToString());
                            Response.ContentType = "application/octet-stream";
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + myZip);
    
                            if (buffer.Length < 1)
                            {
                                return;
                            }
                            if (Response.IsClientConnected)
                            {
                                Response.BinaryWrite(buffer);
                            }
                        }
                    }
                }
            }
            Response.End();
        } 
