    string fileName = "";
            if (FileUpload1.HasFile)
            {
                string dir = "DirectoryPath";
                fileName = Path.Combine(dir, FileUpload1.FileName);
                if (!File.Exists(fileName))
                {
                    FileUpload1.SaveAs(fileName);
                }
                else
                {
                    fileName = Path.Combine(Path.GetDirectoryName(fileName), string.Concat(Path.GetFileNameWithoutExtension(fileName), DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss"), Path.GetExtension(fileName)));
                    FileUpload1.SaveAs(fileName);
                }
            }
            if (fileName != "")
            {
                using (SqlConnection connection = new SqlConnection("MyConnectionString"))
                {
                    string myQuery = "INSERT INTO MyTable(FileName) VALUES(@Filename)";
                    SqlCommand cmd = new SqlCommand(myQuery, connection);
                    cmd.Parameters.AddWithValue("@Filename",fileName); 
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
