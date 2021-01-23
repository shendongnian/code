     protected void lnkDownload_Click(object sender, EventArgs e)
    {
        string strFileName = "Test.txt";// lnkDownload.Text;
        string path = Server.MapPath("~/Attachments//" + strFileName);
        //try
        //{
            if (File.Exists(path))
            {
                byte[] bts = System.IO.File.ReadAllBytes(path);
                MemoryStream ms = new MemoryStream(bts);
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + strFileName + "\"");
                Response.TransmitFile(path);
                Response.End();
            }
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}    
    }
