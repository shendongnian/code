    protected void Page_Load(object sender, EventArgs e)
    {
        Session["memberreportid"] = 1; //TODO: Remove this
        var query = "SELECT TOP 1 * FROM  MemberReport where memberreportid=@p1";
    
        //create the format string for each image. Note the last variable is {0} for additional formating
        string imageSource = string.Format("/viewImage.ashx?memberreportid={0}&imageID={1}", Session["memberreportid"], "{0}");
    
        //set our URL to our Image handler for each image
        Image1.ImageUrl = string.Format(imageSource, 1);
        Image2.ImageUrl = string.Format(imageSource, 2);
        Image3.ImageUrl = string.Format(imageSource, 3);
        Image4.ImageUrl = string.Format(imageSource, 4);
        Image5.ImageUrl = string.Format(imageSource, 5);
    
        //execute our command. Note we are using parameters in our SQL to circumvent SQL injection
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
        {
            var cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandTimeout = 3000;
            cmd.Parameters.AddWithValue("@p1", Session["memberreportid"]);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //hide each image if the image is null or not a byte array (should always be a byte array)
    
                if (reader["image1"] == null || !(reader["image1"] is byte[]))
                    Image1.Visible = false;
                if (reader["image2"] == null || !(reader["image2"] is byte[]))
                    Image2.Visible = false;
                if (reader["image3"] == null || !(reader["image3"] is byte[]))
                    Image3.Visible = false;
                if (reader["image4"] == null || !(reader["image4"] is byte[]))
                    Image4.Visible = false;
                if (reader["image5"] == null || !(reader["image5"] is byte[]))
                    Image5.Visible = false;
    
                //we only want the first row so break (should never happen anyway)
                break;
            }
            con.Close();
        }
    }
