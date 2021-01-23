    <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:RadioButtonList runat="server" ID="rblRecordStatus" RepeatDirection="Vertical" AutoPostBack="true" 
        OnSelectedIndexChanged="rblRecordStatus_SelectedIndexChanged" TextAlign="Right" CssClass="inline-rb">
        <asp:ListItem>ALL</asp:ListItem>
        <asp:ListItem>Active</asp:ListItem>
        <asp:ListItem>Completed</asp:ListItem>
        <asp:ListItem>On Hold</asp:ListItem>
    </asp:RadioButtonList>
