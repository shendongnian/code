    using (SqlConnection connection = new SqlConnection("Asset managementConnectionString")) {
      String query = "INSERT INTO Damage (Area,Building,Conference,Apartment,Room,DescribeDamage) VALUES (@Area,@Building,@Conference,@Apartment,@Room,@DescribeDamage)";
      using (SqlCommand CCC = new SqlCommand(query, connection)) {
        try {
          connection.Open();
          CCC.CommandType = CommandType.Text;
          CCC.Parameters.Add("@Area", SqlDbType.Char, 80).Value =  80;
          CCC.Parameters.Add("@Building", SqlDbType.Char, 9).Value = ddlBuildingCCC.ToString();
          CCC.Parameters.Add("@Conference", SqlDbType.Char, 5).Value = txtConferenceCCC.ToString();
          CCC.Parameters.Add("@Apartment", SqlDbType.VarChar, 4).Value = txtApartmentCCC.ToString();
          CCC.Parameters.Add("@Room", SqlDbType.VarChar, 10).Value = txtRoomCCC.ToString();
          CCC.Parameters.Add("@DescribeDamage", SqlDbType.VarChar, 100).Value = txtDescribeCCC.ToString();
          CCC.ExecuteNonQuery();
        } catch (SqlException) {
          throw; // just rethrow for now
        }
      }
    }
