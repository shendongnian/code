      using (var reader = command.ExecuteReader())
          {
               if (reader.HasRows)
                  {
                     while (reader.Read())
                     {
                       if (txtpCode.Text == "")
                       {
                           txtpCode.Text = dr["prd_code"].ToString();
                       }
                       else if (txtpName.Text == "")
                       {
                           txtpName.Text = dr["prd_name"].ToString();
                       }
                       txtpCompany.Text = dr["prd_company"].ToString();
                       txtUnitPrice.Text = dr["prd_price"].ToString();
                       txtDiscount.Text = dr["prd_dis"].ToString();
                       txtFinalRate.Text = dr["prd_final"].ToString();
                    }
                }
          }
