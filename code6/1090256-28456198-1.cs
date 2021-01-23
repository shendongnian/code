             string connectingString = ConfigurationManager.ConnectionStrings["AccountingPro.Properties.Settings.DAccConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectingString))
            {
                con.Open();
                String query = "INSERT INTO dbo.document (docnum, basicdate, userdate, doctype, amount, AccountNumber, accountname, discounttype, discountpercentage, amountafterdiscount, comments, posted) VALUES(@id, @BD, @UD, @DT, @Am, @anum, @aname, @disT, @disP, @aad, @notes, @de)";
                using (var command = con.CreateCommand()) {
                    command.Parameters.Add("@id", this.ID);
                    command.Parameters.Add("@BD", this.Basic_Date);
                    command.Parameters.Add("@UD", this.User_Date);
                    command.Parameters.Add("@DT", this.Type_of_Doc);
                    command.Parameters.Add("@Am", this.Amount);
                    command.Parameters.Add("@anum", this.account_num);
                    command.Parameters.Add("@aname", this.account_name);
                    command.Parameters.Add("@disT", '0');
                    command.Parameters.Add("@disP", '0');
                    command.Parameters.Add("@aad", '0');
                    command.Parameters.Add("@notes", this.Notes);
                    if (this.departure == false)
                        command.Parameters.Add("@de", '0');
                    else
                        command.Parameters.Add("@de", '1');
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
