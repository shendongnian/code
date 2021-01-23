    string[] commands = sql.Split( 
        new string[]{"GO\r\n", "GO ", "GO\t"}, StringSplitOptions.RemoveEmptyEntries );
    foreach (string c in commands)
    {
        command = new SqlCommand(c, masterConnection);
        command.ExecuteNonQuery();
    }
    }
    catch (Exception e)
    {
        MessageBox.Show(e.Message);
    }
    finally
    {
        masterConnection.Close();
    }
    }
