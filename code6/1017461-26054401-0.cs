     public void Change_Reservation(string pDataAreaId, string pSalesId, string pCustNum, string pNom, SqlConnection Conn)
            {
                try
                {
                    ADV_CdeRAVCollection myColl = new ADV_CdeRAVCollection();
                    using (SqlCommand Com = Conn.CreateCommand())
                    {
                        Com.CommandText = ADV_CdeRAV._SQL_Select_If_Reserve;
                        Com.Parameters.AddWithValue("@DataAreaId", pDataAreaId);
                        using (SqlDataReader rs = Com.ExecuteReader())
                        {
                            while (rs.Read())
                            {
                                ADV_CdeRAV myObj = new ADV_CdeRAV();
                                myObj.AddFromRecordSet_SelectRAV(rs);
                                if (myObj.Nom == null)
                                {
                                    res = "null to nom";
                                }
                                else if (myObj.Nom.Trim() == pNom)
                                {
                                    res = "nom to null";
                                }
                                myColl.Add(myObj);
                            }
                            Com.Dispose();
                            rs.Close();
                            rs.Dispose();
                        }
                    }
        
                    if (res == "nom to null")
                    {
                        //UPDATE NOM TO NULL
                        using (SqlCommand Com2 = Conn.CreateCommand())
                        {
                            Com2.CommandText = ADV_CdeRAV._SQL_Update_Nom_To_Null;
                            Com2.Parameters.AddWithValue("@DataAreaId", pDataAreaId);
                            **Com2.ExecuteNonQuery();**
                            Com2.Dispose(); 
                        }
                    }
                    else if (res == "null to nom")
                    {
                        //UPDATE NULL TO NOM
                        using (SqlCommand Com3 = Conn.CreateCommand())
                        {
                            Com3.CommandText = ADV_CdeRAV._SQL_Update_Null_To_Nom;
                            Com3.Parameters.AddWithValue("@DataAreaId", pDataAreaId);
                            **Com3.ExecuteNonQuery();**
                            Com3.Dispose();
                        }
                    }
                    if (myColl.Count == 0)
                    {
                        //INSERT
                        using (SqlCommand Com4 = Conn.CreateCommand())
                        {
                            Com4.CommandText = ADV_CdeRAV._SQL_Insert_Reservation;
                            Com4.Parameters.AddWithValue("@DataAreaId", pDataAreaId);
                            **Com4.ExecuteNonQuery();**
                            Com4.Dispose();
                        }
                    }
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
