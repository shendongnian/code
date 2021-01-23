    try
                    {
                        using (cn)
                        using (OdbcDataAdapter dadapter = new OdbcDataAdapter(globals.dgsql, cn))
                        {
                            DataTable table = new DataTable();
                            dadapter.Fill(table);
    
                            this.MY_DataGridView.DataSource = table;
                            connection.exitcon();
                        }
                    }
    
                    catch (OdbcException o)
                    {
                        MessageBox.Show(o.ToString(), "Error");
                        return;
                    }
            }
