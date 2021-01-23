        protected void btn_upload_file_server_Click(object sender, EventArgs e)
        {
            if (this.ddl_determinationBit.SelectedIndex != 2)
            {
              btn_upload_file_server.Enabled = false;
              string fileDirectory = @"Y:\Files\"; // Change all reference locations for this: pages Autism.cs & SpecUserAdmin.cs
              string FilePath = Request.PhysicalApplicationPath;
              if (FileUpload1.HasFile)
              {
                  string fileExt = ".html";
                  string fileName = this.txt_fileName.Text + fileExt;
                  string SaveFilePath = fileDirectory + Server.HtmlEncode(fileName);
                  FileUpload1.SaveAs(SaveFilePath);
                  string connstring = WebConfigurationManager.ConnectionStrings["SomeConnectionString"].ConnectionString;
                  SqlConnection conn = new SqlConnection(connstring);
                  SqlCommand SaveMyFile = new SqlCommand("usp_store_document", conn);
                  SaveMyFile.CommandType = CommandType.StoredProcedure;
                  string SQLFileDir = fileDirectory + fileName;
                  SaveMyFile.Parameters.Add(new SqlParameter("@fullpath", SQLFileDir));
                  SaveMyFile.Parameters.Add(new SqlParameter("@filename", this.txt_fileName.Text));
                  SaveMyFile.Parameters.Add(new SqlParameter("@ext", fileExt));
                  int detBit = this.ddl_determinationBit.SelectedIndex;
                  SaveMyFile.Parameters.Add(new SqlParameter("@document_destination_bit", detBit));
                  conn.Open();
                  SaveMyFile.Connection = conn;
                  SaveMyFile.ExecuteNonQuery();
                  conn.Close();
                  // delete all files from the file folder
                  string[] filepaths = Directory.GetFiles(@"Y:\Files\");
                  foreach (string filepath in filepaths)
                      File.Delete(filepath);
                  ddl_determinationBit.SelectedIndex = 2;
                  txt_fileName.Text = "";
                  btn_upload_file_server.Enabled = true;
              }
              else if (ddl_determinationBit.SelectedIndex == 2) lbl_error.Text = "Please where this Document will go";
            }
