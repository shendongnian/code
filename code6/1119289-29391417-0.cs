    protected void Button1_Click(object sender, EventArgs e)
        {
          string g = Server.MapPath(FileUpload1.FileName);
    
          string b =Convert.ToString(FileUpload1.PostedFile.InputStream);
    
          //string filepath = Path.GetFullPath(FileUpload1.FileName.toString());
    
          Label1.Text = g;
          Label2.Text =b;
    
        }
