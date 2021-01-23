    try
    {
       SqlCommand cmd = new SqlCommand(insert_osvsrdetails, Conn);
       cmd.CommandType = CommandType.StoredProcedure;
       //// add out put parameter////
       SqlParameter msg = cmd.Parameters.Add("@msg", SqlDbType.VarChar, 50);
       msg.Size = 50;
       msg.Direction = ParameterDirection.Output;
       /////////////// add input parameter///////////
       IDictionaryEnumerator myEnumerator = osvsr.GetEnumerator();
       while (myEnumerator.MoveNext())
       {
          cmd.Parameters.AddWithValue("@" + (myEnumerator.Key).ToString(), myEnumerator.Value);
          //cmd.Parameters.Add(new SqlParameter("@" + (myEnumerator.Key).ToString(), myEnumerator.Value.ToString().ToUpper()));
       }
       cmd.ExecuteNonQuery();
       strReturn = cmd.Parameters["@msg"].Value.ToString();
       return strReturn;
    }
    finally
    {
       Conn.Close();
    }
