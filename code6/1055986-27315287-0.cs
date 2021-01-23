    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
       <ContentTemplate>
            <asp:Button ID="BT_Test" runat="server" Text="Button" OnClick="BT_Test_Click"></asp:Button>
            <script>
                alert(<%=Session["test"]%>);
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BT_Test"/>
        </Triggers>
    </asp:UpdatePanel>
