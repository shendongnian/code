    private static void SqlCommandPrepareEx(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);
    
            // Create and prepare an SQL statement.
            command.CommandText =
    		"SELECT  name, lat, lng, (6367 * acos( cos( radians(@center_lat) ) * cos( radians( lat ) ) * cos( radians( lng ) - radians(@center_lng) ) + sin( radians(@center_lat) ) * sin( radians( lat ) ) ) ) AS distance FROM table HAVING distance < @radius ORDER BY distance ASC LIMIT 0 , 20");
    		SqlParameter center_lat = new SqlParameter("@center_lat", SqlDbType.Decimal);
            center_lat.Precision = 10;
    		center_lat.Scale = 6;
    		center_lat.Value = YOURVALUEHERE;//latitude of centre
    		command.Parameters.Add(center_lat);
    		SqlParameter center_lng = new SqlParameter("@center_lng", SqlDbType.Decimal);
            center_lng.Precision = 10;
    		center_lng.Scale = 6;
    		center_lng.Value = YOURVALUEHERE;//longitude of centre
    		command.Parameters.Add(center_lng);
    		SqlParameter radius = new SqlParameter("@radius", SqlDbType.Int,3);
            radius.Value = YOURVALUEHERE;
    		command.Parameters.Add(radius);//Radius in km
    		// Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
    
    
        }
    }
