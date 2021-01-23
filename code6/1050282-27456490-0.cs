    MySql.Data.MySqlClient.MySqlDataAdapter myAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter(ds.Tables[0].Rows[0]["Query"].ToString(), conn);
                        myAdapter1.Fill(myData);
                        WaitSumCrystalReport3 myr = new WaitSumCrystalReport3();
                        myr.SetDataSource(myData);
                        if (myData.Tables[0].Rows.Count > 0)
                            myr.PrintToPrinter(1, true, 1, 10);
                        cmd.CommandText = "Update tbl_print set Status='1' where ID='" + ds.Tables[0].Rows[0]["ID"].ToString() + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
    //disposing the crystal report object to clear the temp memroy.. otherwise memory is overflow occurs in future
                        myr.Dispose();
    //above statement is used to dispose... it will work fine
..
