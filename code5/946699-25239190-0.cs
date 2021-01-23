	SqlConnection sqlCon = new SqlConnection("...");
	String sqlScript = "Somethings ...";
	Regex r = new Regex(@"(?<Parameter>@\w*)", RegexOptions.Compiled);
	string[] parameters = r.Matches(sqlScript).Cast<Match>().Select<Match, string>(x => x.Value.ToLower()).Distinct<string>().ToArray<string>();
	SqlCommand sqlCom = new SqlCommand(sqlScript, sqlCon);
	foreach (string sqlParam in parameters)
	{
		sqlCom.Parameters.AddWithValue(sqlParam, "PARAMETER VALUE");
	}
