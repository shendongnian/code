    private void btnAdd_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(constring);
                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand(@"insert into Accounts (date, moneyin, retailin, rent, stock, transport, misc, bills, comments) values (@date, @moneyin, @retailin, @rent, @stock, @transport, @misc, @bills, @comments )";, con);
    
                try
                {
    
                    da.InsertCommand.Parameters.Add("@date", SqlDbType.Date);
                    da.InsertCommand.Parameters["@date"].Value = dtpaccs.Value;
                    da.InsertCommand.Parameters.Add("@moneyin", SqlDbType.Decimal);
                    da.InsertCommand.Parameters["@moneyin"].Value = textmoneyin.Text.Trim();
                    da.InsertCommand.Parameters.Add("@retailin", SqlDbType.Decimal);
                    da.InsertCommand.Parameters["@retailin"].Value = textretailin.Text.Trim();
                    da.InsertCommand.Parameters.Add("@rent", SqlDbType.Decimal);
                    da.InsertCommand.Parameters["@rent"].Value = textrent.Text.Trim();
                    da.InsertCommand.Parameters.Add("@stock", SqlDbType.Decimal);
                    da.InsertCommand.Parameters["@stock"].Value = textstock.Text.Trim();
                    da.InsertCommand.Parameters.Add("@transport", SqlDbType.Decimal);
                    da.InsertCommand.Parameters["@transport"].Value = texttransport.Text.Trim();
                    da.InsertCommand.Parameters.Add("@misc", SqlDbType.Decimal);
                    da.InsertCommand.Parameters["@misc"].Value = textmisc.Text.Trim();
                    da.InsertCommand.Parameters.Add("@bills", SqlDbType.Decimal);
                    da.InsertCommand.Parameters["@bills"].Value = textbills.Text.Trim();
                    da.InsertCommand.Parameters.Add("@comments", SqlDbType.VarChar);
                    da.InsertCommand.Parameters["@comments"].Value = textcomments.Text.Trim();
    
                    con.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Data Added");
                    con.Close();
                    cleartexts();
                    binddata();
                }
    
    
    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
