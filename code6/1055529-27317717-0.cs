     var pageSize = 10;
     var totalPages = Math.Ceiling(table1.Count() / pageSize);
     for(var i = 0; i < totalPages; i++) {
          var addressesToProcess = table1.Skip(i * pageSize).Take(pageSize);
          foreach (var address in addressesToProcess) 
          {
               string strAddr = address.ADDRESS + "," + address.CITY + "," + address.ZIP + "," + address.COUNTRY;
               GoogleMapsDll.GeoResponse myCoordenates = new GoogleMapsDll.GeoResponse();
               myCoordenates = GoogleMapsDll.GoogleMaps.GetGeoCodedResults(strAddr);
               if (myCoordenates.Results != null && myCoordenates.Results.Length > 3)
               {
                    string strLat = myCoordenates.Results[3].Geometry.Location.Lat.ToString();
                    string strLong = myCoordenates.Results[3].Geometry.Location.Lng.ToString();
                    using (SqlConnection myConnection = new SqlConnection(context))
                    {
                        myConnection.Open();
                        string strQueryUpdate = "UPDATE WEB_ARENA_GEO SET Lat = '" + strLat + "', Lng = '" + strLong + "'" + "WHERE ADDRESS_ID='" + address.ADDRESS_ID + "'";
                        SqlCommand myCommandUpdate = new SqlCommand(strQueryUpdate, myConnection);
                        myCommandUpdate.ExecuteNonQuery();
                    }
                    db.SaveChanges();
               }
          }
     }
