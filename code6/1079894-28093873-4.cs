     private void Loadproduction()
     {
          if (comboBox1.SelectedValue.ToString().Trim().Length > 0)
            {
                try
                {
                    using (MSSQL.SqlConnection connection = new MSSQL.SqlConnection(constr))
                    {
                        connection.Open();
                        using (MSSQL.SqlCommand command = new MSSQL.SqlCommand("SELECT TOP (100) PERCENT dbo.[Production Lines].[Production Line Description] AS prodline FROM dbo.[Production Lines] LEFT OUTER JOIN dbo.[Net Weight Master Data] ON dbo.[Production Lines].[Production Line] = dbo.[Net Weight Master Data].[Production Line] RIGHT OUTER JOIN dbo.ItemDesc ON dbo.[Net Weight Master Data].[Unit UPC Base Item] = dbo.ItemDesc.[Unit UPC Base Item] WHERE (dbo.ItemDesc.[Unit UPC Base Item] = '0001') GROUP BY dbo.[Production Lines].[Production Line], dbo.[Production Lines].[Production Line Description], dbo.ItemDesc.[Unit UPC Base Item] ORDER BY dbo.ItemDesc.[Unit UPC Base Item]", connection))
                        {
                            MSSQL.SqlParameter myparam = new MSSQL.SqlParameter();
                            myparam.Direction = ParameterDirection.Input;
                            myparam.ParameterName = "@unitupc";
                            myparam.SqlDbType = SqlDbType.NVarChar;
                            myparam.Size = 50;
                            myparam.Value = comboBox3.Text;
                            command.Parameters.Add(myparam);
                            MSSQL.SqlDataAdapter myadapter = new System.Data.SqlClient.SqlDataAdapter();
                            myadapter.SelectCommand = command;
                            prodline.DataTable2.Clear(); //or u can use prodline.DataTable2.Reset() --Reset removes all data, indexes, relations, and columns of the table
                            myadapter.Fill(prodline, "DataTable2");
                            comboBox2.DataSource = prodline.DataTable2;
                            comboBox2.DisplayMember = "prodline";
                        }
                    }
                }
                catch (Exception) { /*Handle error*/ }
            }
        }
