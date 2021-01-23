            protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            SqlCommand command = conn.CreateCommand();
            try
            {
                command.CommandText = "GetMax";
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();
                object cMax = command.ExecuteScalar();
                if (cMax != DBNull.Value)
                {
                    int CustMax = (int)cMax;
                    CustMax++;
                    txtCustID.Text = CustMax.ToString();
                }
                else
                {
                    txtCustID.Text = "1";
                }
            }
            catch (SqlException)
            {
                lblMessage.Text = "Cannot connect to database";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                command.Dispose();
                conn.Dispose();
            }
        }
