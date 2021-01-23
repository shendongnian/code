    foreach (string gameTitle in ddlgameTile.Items)
    {
    	if (printHouseData == gameTitle)
    	{
    		ddlgameTile.SelectedIndex = ddlgameTile.Items.IndexOf(ddlgameTile.Items.FindByValue(gameData));
    	}
    	else
    	{
    		txtNewGame.Text = readGame["gTitle"].ToString();
    		ddlgameTile.SelectedIndex = ddlgameTile.Items.IndexOf(ddlgameTile.Items.FindByValue("Others"));
    	}
    }
