            bool result = false;
            try
            {
                SqlConnection SCO = ConnectionClass.getconnection();
                SqlCommand delCmd = new SqlCommand(ReadCommand, SCO);
                if (SCO.State != ConnectionState.Open) SCO.Open();
                SqlDataReader r = delCmd.ExecuteReader();
                if (r.Read()==true)
                {
                    if (SCO.State != ConnectionState.Closed) SCO.Close();
                    r.Close();
                    result = true;
                }
                else if (r.Read() == false)
                {
                    if (SCO.State != ConnectionState.Closed) SCO.Close();
                    r.Close();
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
