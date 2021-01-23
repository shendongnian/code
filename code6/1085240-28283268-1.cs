    private void BindRepeater()
    {
        if (mainPage.TemplateID.ToString() != "{27A9692F-AE94-4507-8714-5BBBE1DB88FC}")
        {
            rptAdresses.Visible = false;
        }
        else
        {
            rptAdresses.DataSource = Sitecore.Context.Item.GetChildren();
            rptAdresses.DataBind();
        }
    }
