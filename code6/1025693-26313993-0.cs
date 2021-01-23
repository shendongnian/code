    public SqlDataReader getpartyID(string partyName)
                {
                    string query = "EXEC partyIDtoInsert'" +partyName.Replace("'", "''") + "'";
                    return new DataAccessLayer().executeQuerys(query);
                 }
