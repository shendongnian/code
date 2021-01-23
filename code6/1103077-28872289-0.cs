    public static Partner GetOnePartner(string code)
     {
        Partner partner = new Partner();
        string sqlStatement = "SELECT * FROM partners WHERE partner_code = @partner_code";
        using(SQLiteConnection connection = GroomwatchDB.GetConnection())
        using(SQLiteCommand command = new SQLiteCommand(sqlStatement, connection))
        {
			command.Parameters.Add(new SQLiteParameter("@partner_code"));
			command.Parameters["@partner_code"].Value = code;
			connection.Open();
			SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
			if(reader.Read())
			{
				partner.Code = reader["partner_code"].ToString();
				partner.Last_name = reader["last_name"].ToString();
				partner.First_name = reader["first_name"].ToString();
				partner.Pay_rate = (double)reader["pay_rate"];
				partner.Active = reader["active"].ToString();
			}
			else
			{
				partner.Code = code;
				partner.Last_name = "Not Found";
			}
        }
        return partner;
    } 
