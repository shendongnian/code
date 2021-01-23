     var cmd = new AdomdCommand(@"evaluate (
                        'Geography')
                        order by 'Geography'[Geography Id]
                        ", conn);
                    AdomdDataReader objReader = cmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        var geographyInformation = new GeographyInformation
                        {
                            GeographyId = Convert.ToInt32(objReader.GetString(0)),
                            City = objReader.GetString(1),
                            StateProvinceCode = objReader.GetString(2),
                            State = objReader.GetString(3),
                            CountryRegionCode = objReader.GetString(4),
                            CountryRegionName = objReader.GetString(5),
                            PostalCode = objReader.GetString(6),
                            SalesTerriortyId = Convert.ToInt32(objReader.GetString(7))
                        };
                        geographyViewModel.GeographyInfo.Add(geographyInformation);
                    }
                    objReader.Close();
