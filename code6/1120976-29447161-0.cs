     if (txtdol.Text == null || txtdol.Text == string.Empty)
                            {
                                cmd.Parameters.Add("@leaving_date", SqlDbType.DateTime).Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters.Add("@leaving_date", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdol.Text);
                            }
