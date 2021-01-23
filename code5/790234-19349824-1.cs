	protected void Page_Load(object sender, EventArgs e)
	{
		if (rdr.Read())
		{
			TinyMCE.InnerText = (string)rdr["HTML"];
		}
	}
	protected void Submit_Click(object sender, EventArgs e)
	{
		string RenderedHTML = TinyMCE.InnerText;
		string query = "UPDATE cms.Main SET HTML = @Text WHERE ID = @ID";
		SqlCommand cmd = new SqlCommand(query, conn);
		cmd.Parameters.Add("@Text", SqlDbType.Text).Value = RenderedHTML;
		cmd.Parameters.Add("@ID", SqlDbType.Int).Value = TargetPage;
	}
