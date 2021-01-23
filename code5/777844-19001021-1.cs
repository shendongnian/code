                        //Get byte array from image file in the database with basic query
                        SqlDataAdapter myAdapter1 = new SqlDataAdapter("Select [logo] FROM [dbo].[tblCompanyInfo]", GlobalUser.currentConnectionString);
                        DataTable dt = new DataTable();
                        myAdapter1.Fill(dt);
                        
                        foreach (DataRow row in dt.Rows)
                        {
                            //Get the byte array from image file
                            byte[] imgBytes = (byte[])row["logo"];
                            //If you want convert to a bitmap file
                            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                            Bitmap MyBitmap = (Bitmap)tc.ConvertFrom(imgBytes );
                            string imgString = Convert.ToBase64String(imgBytes);
                            //Set the source with data:image/bmp
                            imgLogoCompany.Src = String.Format("data:image/Bmp;base64,{0}\"", imgString);
    
                        }
