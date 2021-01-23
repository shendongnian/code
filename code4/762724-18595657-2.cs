    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
         <section style="vertical-align: middle">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
                <ContentTemplate>
                    <vmsc:DeviceRow ID="DeviceRow11" BorderStyle="Solid" runat="server"> </vmsc:DeviceRow>
                     <br />
                    <br />
                     <asp:Button ID="Button1" runat="server"
                     Text="Click Me" OnClick="Button1_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </section>    
    </asp:Content>
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        DeviceRow11.BorderStyle = BorderStyle.None;
    }
