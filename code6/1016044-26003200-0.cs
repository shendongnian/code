    [WebMethod]
    public static List<string> GetPreviousSaltsAndHashes(string name)
    {
        List<string> prevSalts = new List<string>();
        // Note: This totally sticks. It's unclear what this reader instance is but if it is a 
        // SqlReader, as it name suggests, it should probably be wrapped in a using statement
        if (reader.HasRows)
        {
            while (reader.Read())
            {                      
                prevSalts.Add(reader.GetString(0));
            }
        }
        // Note: This totally sticks. It's unclear what this conn instance is but if it is a 
        // SqlConnection, as it name suggests, it should probably be wrapped in a using statement
        conn.Close();
            return prevSalts;
        }
    }
