    string sql = @"SELECT QType FROM InventoryQType WHERE ItemID=@id";
    using (SqlConnection conn = new SqlConnection("[put your connection string here, or reference to web.config]")) {
    	conn.Open();
    	using (SqlCommand cmd = new SqlCommand(sql, conn)) {
    		cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = itemID;
    		SqlDataReader rdr = cmd.ExecuteReader();
    		int loop = 1;
    		while (rdr.Read()) {
    			switch(loop){
    				case 1:
    					QuantityType1TxtBox.Text = (string)rdr["QType"];
    					break;
    				case 2:
    					QuantityType2TxtBox.Text = (string)rdr["QType"];
    					break;
    				case 3:
    					QuantityType3TxtBox.Text = (string)rdr["QType"];
    					break;
    				case 4:
    					QuantityType4TxtBox.Text = (string)rdr["QType"];
    					break;
    				case 5:
    					QuantityType5TxtBox.Text = (string)rdr["QType"];
    					break;
    				default:
    					break;
    			}
    			loop++;
    		}
    	}
    	conn.Close();
    }
