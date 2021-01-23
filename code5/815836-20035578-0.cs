    protected void Button1_Click(object sender, EventArgs e)
            {            
           int TotalCostWeight=getTotalWeightandCost();    
            }
        
         private   int getTotalWeightandCost()
            {
                int total = 0;
                String strCon = "Data Source=systemname;Initial Catalog=databasename;uid=uid;pwd=pwd;Integrated Security=True;";
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    String strCmd = "SELECT Cost*Weight as total FROM [Human] WHERE [Name] = @Name";
                    using(SqlCommand sqlcommand = new SqlCommand(strCmd, sqlCon))
                    sqlCon.Open();
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = DropDownList1.SelectedValue.ToString();
                    SqlDataReader sReader = sqlcommand.ExecuteReader();
                    if (sReader.Read())
                        total = Convert.ToInt32(sReader[0].ToString());
                }
            }
                return total;
            }
