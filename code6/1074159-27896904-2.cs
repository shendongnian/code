            string StrConection = "Data Source=XXXX;Initial Catalog=ExampleDB;Integrated Security=True";
            using (SqlConnection Conection = new SqlConnection(StrConection))
            {
                Conection.Open();
                using(SqlCommand Command = new SqlCommand("INSERT INTO Images VALUES(@Name,@Image);",Conection))
                {
                    //Get bytes from PictureBox
                    Image img = picBox.Image;
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = ms.ToArray();
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.Add("@Name",SqlDbType.VarChar,10).Value = txtName.Text;
                    Command.Parameters.Add("@Image", SqlDbType.Binary, 8000).Value = bytes;
                    Command.ExecuteNonQuery();
                }
                Conection.Close();
            }
