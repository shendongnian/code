       try
		{
			using (MySqlConnection conn = new MySqlConnection(constr))
			{
				using (MySqlCommand cmd = new MySqlCommand())
				{
					string sql = "SELECT Count(comment.Topic_Id) FROM comment inner join topic on(comment.Topic_Id=topic.id) group by topic.id limit " + start + ",10";
					conn.Open();
					cmd.Connection = conn;
					cmd.CommandText = sql;
					MySqlDataReader rdr = cmd.ExecuteReader();
					while (rdr.Read())
					{
						numberOfcomments[i] = rdr.GetInt16(0);
						i++;
					}
				}
			}
			return numberOfcomments;
		}
		catch(Exception ex)
		{
                        
			return ex.Message;
		}
