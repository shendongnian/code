	using System.Data;
	using System.Data.SqlClient;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.Form["Name"] == null) Response.End();
		if (Request.Form["ID"] == null) Response.End();
		//Connection string
		SqlConnection conn = new SqlConnection("Data Source=sqlsvr.net;Initial Catalog=ohsrespirator;Persist Security Info=True;User ID=user;Password=pwd");
		//Set a command
		SqlCommand cmd = new SqlCommand("UPDATE Table_Name SET Column_Name = @value1, Column_ID = @value2", conn);
		cmd.Parameters.Add("@value1", SqlDbType.NVarChar).Value = Request.Form["Name"] as string;
		cmd.Parameters.Add("@value2", SqlDbType.NVarChar).Value = Request.Form["ID"] as string;
		//Open connection and execute update
		try
		{
			conn.Open();
			cmd.ExecuteNonQuery();
		}
		catch { }
		finally { if (conn != null) conn.Close(); }
	}
