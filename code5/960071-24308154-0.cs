    protected void gvPlayers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int ndex = int.Parse(e.CommandArgument.ToString());
            int key = int.Parse(gvPlayers2.DataKeys[ndex].Value.ToString());
            PlayersLogic pl = new PlayersLogic();
            pl.RemovePlayerFromTeam(key);
        }
    }
    protected void gvPlayers2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (OnPlayerRemovedFromTeam != null)
        {
            OnPlayerRemovedFromTeam(this, e);
        }
        LoadPlayers(true);
    }
