    private void getData()
        {
            String strCon = "Data Source=(local);Initial Catalog=database;uid=uid;pwd=pwd;Integrated Security=True;";
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                String strCmd = "select PartNumber,PartName,BeginingStok from Part";
                using (SqlCommand sqlcommand = new SqlCommand(strCmd, sqlCon))
                {
                    sqlCon.Open();
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlcommand))
                    {
                        DataSet ds = new DataSet();
                        sqlAdapter.Fill(ds);
                        //DG.DataSource = ds.Tables[0];
    
                        foreach (DataRow newrow in ds.Tables[0].Rows)
                        {
    
                            
                            String str = "";
                            for (int i = 0; i < 8; i++)
                            {
                                if (i == 0) str = "Forecast";
                                if (i == 1) str = "Stok Condition by Forecast";
                                if (i == 2) str = "Production";
                                if (i == 3) str = "Stok Condition by Production";
                                if (i == 4) str = "Safety Stok";
                                if (i == 5) str = "Schedjule Receipt";
                                if (i == 6) str = "Outgoing";
                                if (i == 7) str = "PO Release";
    
                                DG.Rows.Add();
                                int row = DG.RowCount - 1;
                                if (i == 0)
                                    DG.Rows[row].Cells[0].Style.ForeColor = Color.Black;
                                else
                                    DG.Rows[row].Cells[0].Style.ForeColor = Color.White;
    
                                DG.Rows[row].Cells[0].Value = newrow["PartNumber"];
                                DG.Rows[row].Cells[1].Value = newrow["PartName"];
                                DG.Rows[row].Cells[2].Value = str;
                                DG.Rows[row].Cells[3].Value = newrow["BeginingStok"];
                            }
    
    
                        }
                    }
                }
            }
        }
