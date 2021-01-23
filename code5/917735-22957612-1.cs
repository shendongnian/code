    <asp:UpdatePanel runat="server" ID="up1">
        <ContentTemplate>
            <asp:TextBox ID="uname" runat="server" AutoPostBack="True"
                OnKeyDown="TextChanged(this)" OnTextChanged="uname_TextChanged"></asp:TextBox>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="uname" />
        </Triggers>
    </asp:UpdatePanel>
