            com.CommandText = ("INSERT INTO SMSArchives(Message,Blacklist) VALUES (@par1,@par2)");
            command.Parameters.Add(new SqlParameter("@par1", ""));
            com.Parameters.AddWithValue("@par2", "Yes");
            foreach (DecodedShortMessage message in messages)
            {
                command.Parameters["@par1"].Value = message.Data.UserDataText;
                com.ExecuteNonQuery();
            }
