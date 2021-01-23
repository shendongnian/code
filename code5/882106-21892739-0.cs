    var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    
    var command = "INSERT INTO Damage (Area,Building,Conference,Apartment,Room,DescribeDamage) VALUES (@Area,@Building,@Conference,@Apartment,@Room,@DescribeDamage)";
    
    using (SqlConnection cnn = new SqlConnection(cnnString))
    {
        using (SqlCommand cmd = new SqlCommand(command, cnn))
        {
            cmd.Parameters.AddWithValue("@Area", "80"); // Hardcoded value? Should be an int btw.
            cmd.Parameters.AddWithValue("@Building", ddlBuildingCCC.ToString());
            cmd.Parameters.AddWithValue("@Conference", ddlBuildingCCC.ToString());
            // ... the other values
    
            cnn.Open();
            cmd.ExecuteNonQuery();
        }
    }
