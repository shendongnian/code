                    string sql = "";
                    string address = "";
                    SqlConnection con = new SqlConnection(ConnectionString);
                    sql = "SELECT Image from ImageTable where imageId=1";
          
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(ds,"Data");
    
            
                    address = "C:\\Users\\CARDIT\\Desktop\\Imag1.jpeg";
                    byte[] bytes = (byte[])ds.Tables["Data"].Rows[i][0];
                   MemoryStream ms = new MemoryStream(bytes);
                   
    
                   System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                      
                        Bitmap bmSave = new Bitmap(returnImage);
                        Bitmap bmTemp = new Bitmap(bmSave);
    
                        Graphics grSave = Graphics.FromImage(bmTemp);
                        grSave.DrawImage(returnImage, 0, 0, returnImage.Width, returnImage.Height);
    
                        bmTemp.Save(address); //If You want to save in Specific location
                     
                        pictureBox1.Image = bmSave; //if you want to use Image in Picturebox Control;
               
  
