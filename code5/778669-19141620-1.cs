    protected void Page_Load(object sender, EventArgs e)
    {
        using (
            SqlConnection conn =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            // Query the table to get the list of image IDs for the current user
            SqlCommand cmd = new SqlCommand("SELECT ImageId FROM PoliceMedal WHERE policeid = " + Session["policeid"], conn);
            conn.Open();
            SqlDataReader imageReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            // For each image in the database
            while (imageReader.Read())
            {
                // Create the new Image control
                Image medalImage = new Image();
                // Call the handler, passing the id of the image in the querystring
                medalImage.ImageUrl = string.Format("ImageHandler.ashx?ImageId={0}",
                                                    imageReader.GetInt32(0));
                // Add the image to the placeholder
                MedalPlaceHolder.Controls.Add(medalImage);
            }
        }
    }
