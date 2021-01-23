    string ImagePath = "";
 
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
    SqlCommand cmd = new SqlCommand("SELECT photo FROM othersInfo WHERE empID='" + s + "'", con);
    cmd.CommandType = CommandType.Text;
    con.Open();
    SqlDataReader dataReader = cmd.ExecuteReader();
    if(dataReader.HasRows)
    {
      dataReader.Read();
      ImagePath = Convert.ToString(dataReader["photo"]);
    }
    if (ImagePath != "") 
    {
      Image image = Image.FromFile(ImagePath)
      pictureBox1.Image = image;
    } 
