    protected void Page_Load(object sender, EventArgs e)
            {   
        
                if (Session["userName"] != null)
                {
                    string sql = "select * from users where username='" + Session["userName"]+"'";
                    SqlDataReader sdr = operateData.getRow(sql);
                    sdr.Read();
                    id = Int32.Parse(sdr["Id"].ToString());
        
                    sql = "select * from profiles where userId='" + id+"'";  
                    SqlDataReader sdrPr = operateData.getRow(sql);
                    sdrPr.Read();
        
                SqlConnection con = operateData.createCon();
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    DataRow row = dt.Rows[0];
                    byte[] imgBytes = (byte[])row["img"];
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
        
                    string filePath = Server.MapPath("temp") + "//" + "img" + DateTime.Now.Ticks.ToString() + ".png";
                    FileStream fs = File.Create(filePath);
                    fs.Write(imgBytes, 0, imgBytes.Length);
                    fs.Flush();
                    fs.Close();
        
                    profileImage.ImageUrl = "img" + DateTime.Now.Ticks.ToString() + ".png";
        
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }       
            }
