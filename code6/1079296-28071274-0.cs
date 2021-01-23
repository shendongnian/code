	protected void Page_Load(object sender, EventArgs e)
	{
		using(var con = new MySqlConnection(<args>))
		{
			
		} //at the end of this block, the connection will be Disposed automatically.
	}
