     private System.Windows.Forms.PictureBox picImage;   
    
     SqlConnection con = new SqlConnection(GetConnectionString());
    
        SqlCommand cmd = new SqlCommand("ReadImage", con);
        cmd.CommandType = CommandType.StoredProcedure; 
    
        cmd.Parameters.Add("@imgId", SqlDbType.Int).Value = Convert.ToInt32(cmbImageID.SelectedValue.ToString());
    
   
         SqlDataAdapter adp = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    try
       {
        if (con.State == ConnectionState.Closed)
        con.Open();
         adp.Fill(dt);
       if (dt.Rows.Count > 0)
           {
            MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["ImageData"]);
            picImage.Image = Image.FromStream(ms);
            picImage.Image.Save(@"Complete path of location", ImageFormat.Jpeg);
                        }
                    }
                    catch (Exception ex)//catch if any error occur
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)//check whether connection to database is open or not
                            con.Close();
                    }
                }
               
