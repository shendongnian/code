    public void Crud(string flag, string parameter1, string parameter2) 
     {
            // take ConnectionString as defined in your webConfig or as per your requirement.
            SqlConnection cn = new SqlConnection("ConnectionString");
            SqlCommand cmd = new SqlCommand("StoreProcedure");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 1).Value = flag; // I for Insert/ U for Update/ D for delete/ S for select
            cmd.Parameters.Add("@Parameter1", SqlDbType.VarChar, 50).Value = parameter1;
            cmd.Parameters.Add("@Parameter2", SqlDbType.VarChar, 25).Value = parameter2;
            cn.Open();
            if (flag != "S")
            {
                cmd.ExecuteNonQuery();
            }
            else
            {
                // If you have grid view you can bind it here.
                gridView.DataSource = cmd.ExecuteReader();
            }
            cn.Close();
        }
