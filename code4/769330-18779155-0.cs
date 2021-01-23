    //code for retrival of image from sql server////////////
    			
    			
    			string sql = String.Format("Select Emp_Pic_ImageData From Employees where Emp_Id='{0}'", TxtBoxId.Text);
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    byte[] img = (byte[])(reader[0]);
                    if (img == null)
                    {
                        PicboxEmployee.Image = null;
                    }
                    else
                    {
                        MemoryStream mstrm = new MemoryStream(img);
                        PicboxEmployee.Image = new System.Drawing.Bitmap(mstrm); //there is error of parameter is not valid.
    
                    }
                }
                else
                {
    
                    MessageBox.Show("this not exists");
    
                }
