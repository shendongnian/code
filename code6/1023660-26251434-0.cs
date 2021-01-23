            List<ClsAdvertisement[]> services = new List<ClsAdvertisement[]>();
            using (IDataReader dr1 = cmd1.ExecuteReader())
            { 
                while (dr1.Read())
                {
                    ClsAdvertisement[] qualities = { new ClsAdvertisement(), new ClsAdvertisement(), new ClsAdvertisement() };
                    if (!dr1.IsDBNull(dr1.GetOrdinal("id")))
                    {
                        qualities[0].typical = double.Parse(dr1["id"].ToString());
                        qualities[0].type = "id";
                        qualities[0].min = qualities[0].typical;
                    }
                    if (!dr1.IsDBNull(dr1.GetOrdinal("a")))
                    {
                        qualities[1].typical = double.Parse(dr1["a"].ToString());
                        qualities[1].type = "a";
                        qualities[1].min = qualities[1].typical - 1.0;
                    }
                    if (!dr1.IsDBNull(dr1.GetOrdinal("b")))
                    {
                        qualities[2].typical = double.Parse(dr1["b"].ToString());
                        qualities[2].type = "b";
                        qualities[2].min = qualities[2].typical - 1.0;
                    }
                    services.Add(qualities);
                }
            }
