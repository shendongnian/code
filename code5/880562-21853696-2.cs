    try
            {
                int i = Convert.ToInt32(CBCompanies.SelectedValue.ToString());
                DataTable td = new DataTable();
                da = new SqlDataAdapter("select * from tblCustomerCompany where CustomerID =" + CBCompanies.SelectedValue.ToString() + "  ORDER BY CustomerName", conn);
                conn.Open();
                da.Fill(td);
                conn.Close();
                textBox3.Text = td.Rows[0].ItemArray[5].ToString();
            }
            catch
            {
 
            }  
