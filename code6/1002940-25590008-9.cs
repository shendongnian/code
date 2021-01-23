        protected void rptMyRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ShowID":
                    lblMsg.Text = e.CommandArgument.ToString();
                    break;
                case "ShowTitle":
                    lblMsg.Text = e.CommandArgument.ToString();
                    break;
            }
        }
