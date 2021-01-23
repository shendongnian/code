     while (reader.Read())
                {
                    int ordinal2 = reader.GetOrdinal("Id");
                    for (int i=0; i<=ordinal2; i++)
                    {
                        string[] divisionIDs = new string[i];
                        divisionIDs[i] = reader.GetString(ordinal2);
                    }
                }
