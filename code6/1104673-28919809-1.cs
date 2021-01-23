            ClientScriptManager cs = Page.ClientScript;
            string csName = "MyScript";
            Type csType = this.GetType();
            for(int i = 1; i <= 10; i++)
            {
                string currentName = string.Format("{0}{1}", csName, i);
                if (!cs.IsStartupScriptRegistered(csType, currentName))
                {
                    string csText = string.Format("myFunction('{0}');", i);
                    cs.RegisterStartupScript(csType, currentName, csText, true);
                }
            }
