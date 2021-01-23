    protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    String path = Server.MapPath("~\\Voter\\Photos\\");
                    Response.Write(path + FileUpload1.FileName);
                    FileUpload1.SaveAs(path + FileUpload1.FileName);
                }
    
            }
            catch (Exception ex)
            {
    
            }
        }
