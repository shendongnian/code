            ClientScriptManager cs = Page.ClientScript;
            string csName = "MyScript";
            Type csType = this.GetType();
            int i = 1;
            while (i < 10)
            {
                if (!cs.IsStartupScriptRegistered(csType, csName + i.ToString()))
                {
                    string csText = "myFunction('" + i + "');";
                    cs.RegisterStartupScript(csType, csName + i.ToString(), csText, true);
                }
                i++;
            }
