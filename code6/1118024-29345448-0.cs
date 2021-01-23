      using (sqlDatAdapter = new SqlDataAdapter(sqlCmd.CommandText, connection))
                    {
                        sqlDatAdapter.SelectCommand.Parameters.Add("@filter", SqlDbType.Int, 25).Value = CusIdEnter;
                        sqlDatAdapter.Fill(datTable);
                        form1.setDataGrid = datTable;
                    }
