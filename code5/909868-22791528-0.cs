	protected void Page_Load(object sender, EventArgs e)
	{
		for (int i = 0; i < form1.Controls.Count; i++)
		{
			if ((form1.Controls[i]) is RadGrid)
				Response.Write(string.Format("found a grid with ID: {0}<br />", form1.Controls[i].ClientID));
		}
	}
