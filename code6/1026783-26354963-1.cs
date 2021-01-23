	public static Verb GetVerbs(string verb)
	{
		Verb v = new Verb();
		
		string sql = @"SELECT	BaseForm, PastForm, PastPartForm
						FROM	EnglishVerbs
						WHERE	@Verb IN (BaseForm, PastForm, PastPartForm);";
						
		string connString = "Data Source=.;Initial Catalog=QABase;Integrated Security=True";
		using (var connection = new SqlConnection(connString))
		using (var command = new SqlCommand(sql, connection))
		{
			command.Parameters.Add("@Verb", SqlDbType.VarChar, 50).Value = verb;
			connection.Open();
			
			using (var reader = command.ExecuteReader())
			if (reader.Read())
			{
				v.BaseTense = Convert.ToString(myReader["BaseForm"]);
				v.PastTense = Convert.ToString(myReader["PastForm"]);
				v.PastParticiple = Convert.ToString(myReader["PastPartForm"]);
			}
		}
		return v;
	}
