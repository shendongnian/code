    string sqlIns = "INSERT INTO table (name, information, other) 
                         VALUES (@name, @information,@other)";
    db.Open();
    
    try
    {
    SqlCommand cmdIns = new SqlCommand(sqlIns, db.Connection);
    cmdIns.Parameters.Add("@name", info);
    cmdIns.Parameters.Add("@information", info1);
    cmdIns.Parameters.Add("@other", info2);
    cmdIns.ExecuteNonQuery();
    cmdIns.Dispose();
    cmdIns = null;
    }
    catch(Exception ex)
    {
    throw new Exception(ex.ToString(), ex);
    }
    finally
    {
    db.Close();
    }
