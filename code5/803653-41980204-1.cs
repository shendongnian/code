    protected void Page_Init(object sender, EventArgs e)
            {
                try
                {
                    if (!ClientScript.IsStartupScriptRegistered(GetType(), "MaskedEditFix"))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "MaskedEditFix", String.Format("<script type='text/javascript' src='{0}'></script>", Page.ResolveUrl("../Javascript/MaskedEditFix.js")));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
