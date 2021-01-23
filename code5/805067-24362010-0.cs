    protected void rbThemes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsSecondPass()) return;
        Server.Transfer(Request.FilePath, true); 
    }
    
    private bool IsSecondPass()
    {
        const string key = "SECOND_PASS_GUARD";
        if (Context.Items[key] == null)
        {
            Context.Items[key] = new object();
            return false;
        }
        else
        {
            Context.Items.Remove(key);
            return true;
        }
    }
