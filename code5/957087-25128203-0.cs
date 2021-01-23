    protected void update_Click(object sender, EventArgs e)
                {
                    foreach (GridViewRow row in SomeGrid.Rows)
                    {
                        TextBox SomeTextBox = row.FindControl("SomeTextBox") as TextBox;
                        CustomValidator validator = row.FindControl("SomeValidator") as CustomValidator;
                        string Account = SomeTextBox.Text;
                        using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                        using (SqlDataAdapter da = new SqlDataAdapter("SELECT Account FROM Account WHERE Account = @Account", conn))
                        {
                            da.SelectCommand.Parameters.Add("@Account", SqlDbType.VarChar);
                            da.SelectCommand.Parameters["@Account"].Value = Account;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                validator.IsValid = true;
                            }
                            else
                            {
                                validator.IsValid = false;
                            }
                        }
                    }
                }
