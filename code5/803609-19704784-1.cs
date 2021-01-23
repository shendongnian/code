    protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string FileName = FileUpload1.PostedFile.FileName;
                SqlConnection con = new SqlConnection(
                    "Data Source=.\\SQLEXPRESS;
                     AttachDbFilename=E:\\Assignment\\App_Data\\MyDatabase.mdf;
                     Integrated Security=True;User Instance=True");
                SqlCommand cmd;
                con.Open();
                cmd = new SqlCommand("UPDATE application 
                                      SET filename= '" + FileName + "' 
                                      WHERE stulastname = '" + DropDownList1.SelectedValue + "' ");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                string path = Server.MapPath("~/App_Data/userfiles");
                bool isExists = System.IO.Directory.Exists(path);
                if (!isExists)
                    System.IO.Directory.CreateDirectory(path);
                var file = Path.Combine(path, FileUpload1.FileName);
                FileUpload1.SaveAs(file);
            }
        }
