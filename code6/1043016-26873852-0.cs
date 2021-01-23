	public static string LoadRow(this SqlDataAdapter adapter, int theRow)
	{
		return adapter.Rows[theRow]["ID"].ToString();
	}
	public static string LoadRow(this OleDataAdapter adapter, int theRow)
	{
		return adapter.Rows[theRow]["ID"].ToString();
	}
