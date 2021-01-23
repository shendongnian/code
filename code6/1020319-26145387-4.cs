                    foreach(var row in data)
                    {
                        string strAddr = row.ADDRESS1 + "," + row.CITY; //here you've to write the exact address you want to geo
    
                        GoogleMapsDll.GeoResponse myCoordenadas = new GoogleMapsDll.GeoResponse();
                        myCoordenadas = GoogleMapsDll.GoogleMaps.GetGeoCodedResults(strAddr);
                        
                        string strLat = myCoordenadas.Results[0].Geometry.Location.Lat.ToString();  
                        string strLong = myCoordenadas.Results[0].Geometry.Location.Lng.ToString();
                        
                        System.Threading.Thread.Sleep(2000); //THIS IS AN API LIMITs
                        
                        //this is just an example to update your sql rows, you can use the info where you need
                        using(SqlConnection myConnection = new SqlConnection(yourConnectionString))
                        {
                            myConnection.Open();
                            string strQueryUpdate = "UPDATE yourAddressTable SET lat = '" + strLat + "' , lon = '" + strLong + "' "
                                + "WHERE yourId = '" + row.YourId + "' ";
                            
                            SqlCommand myCommandUpdate = new SqlCommand(strQueryUpdate, myConnectionUpdate);
                            myCommandUpdate.ExecuteNonQuery();
                        }
    
                     }
