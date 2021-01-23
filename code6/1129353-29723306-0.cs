    <asp:ListView ID="lvNotification" OnItemCommand="lvNotification_OnItemCommand" runat="server">
      <ItemTemplate>
        <asp:LinkButton runat="server" ID="lbReject" CommandName="Reject_Click" CommandArgument='<%# Eval("offerID") %>' Text="Reject" />
      </ItemTemplate>
    </asp:ListView>
    protected void lvNotification_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (String.Equals(e.CommandName, "Reject_Click"))//or any other event
        {
            LinkButton lbreject = (LinkButton) sender;
            string c = lbreject.CommandArgument;
        }
    }
