    public static bool createUser(Player player)
    {
       MySqlCommand cmd = new MySqlCommand("INSERT INTO tbuser (id,sName,lbFoto) VALUES (@id,@name,@foto)", dbConnection);
       cmd.Parameters.AddWithValue("@id", player.id).DbType = DbType.Int32;
       cmd.Parameters.AddWithValue("@name", player.Name).DbType = DbType.String;
       cmd.Parameters.AddWithValue("@foto", player.Image).DbType = DbType.Binary;
       try
       {
           if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
                cmd.ExecuteNonQuery();
                dbConnection.Close();
                return true;
            }            
        }
        catch { }
        finaly
        { 
           if (dbConnection.State == ConnectionState.Open)
                dbConnection.Close();
        }
        return false;
     }
