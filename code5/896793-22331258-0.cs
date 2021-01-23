    SqlCommand query2 = new SqlCommand("SELECT lon , lat FROM Student Where B_ID = @B_ID ORDER BY Distance ASC");
        // some value for @B_ID
        query2.Connection = cn;
        SqlDataReader readStd = query2.ExecuteReader();
        double tempLong = 0.0;
        double tempLat = 0.0;
        bool isFirstIteration = true;
        while (readStd.Read())
            {
                if(isFirstIteration)
                {
                    isFirstIteration = false;
                }
                else
                {
                    double d = DistanceBetweenPlaces(tempLong, tempLat, Convert.ToDouble(readStd.GetValue(0)), Convert.ToDouble(readStd.GetValue(1)));
                    totalDistance = totalDistance + d;
                }
                tempLong = Convert.ToDouble(readStd.GetValue(0));
                tempLat = onvert.ToDouble(readStd.GetValue(1));            
            }
