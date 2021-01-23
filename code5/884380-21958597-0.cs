    <asp:ScriptManager runat="server" ID="S"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="U" UpdateMode="Conditional">
        <ContentTemplate>
                <asp:Button runat="server" ID="Btnnew" Text="new" OnClick="Btnnew_Click" />
                <asp:FileUpload runat="server" ID="FU" />
                <asp:Button runat="server" ID="Btnok" OnClick="Btnok_Click" Text="ok" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Btnok" />
        </Triggers>
    </asp:UpdatePanel>
