      <asp:LinkButton runat="server" ID="LinkButtonA" CommandArgument="A" OnClick="LinkButtonA_OnClick"></asp:LinkButton>
        protected void lb LinkButtonA_OnClick(object sender, EventArgs e)
        {
            var lb = (LinkButton) sender;
            Session["LastNameFilter"] = lb.CommandArgument;
        }
