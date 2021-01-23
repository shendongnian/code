    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Write("Clicked Canceled");
    }
    
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("Clicked OK");
    }
    
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        String csname = "PopupScript";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        if (!cs.IsStartupScriptRegistered(cstype, csname))
        {
            String cstext = "confirmProcess();";
            cs.RegisterStartupScript(cstype, csname, cstext, true);
        }
    }
