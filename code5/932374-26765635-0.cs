	protected void Page_PreInit(object sender, EventArgs e)
	{
		try
		{
			var masterPage = Page.Master as MasterPages.Toolbox;
			if (masterPage != null)
			{
				var form = masterPage.FindControl("form1") as HtmlForm;
				if (form != null)
				{
					if (string.IsNullOrEmpty(form.Action))
					{
						if (string.IsNullOrEmpty(Request.Url.Query))
						{
							form.Action = "default.aspx";
						}
						else
						{
							form.Action = "default.aspx" + Request.Url.Query;
						}
					}
				}
			}
		}
		catch (Exception exception)
		{
			// Handle exception...
		}
	}
