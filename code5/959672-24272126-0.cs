    <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="buttonOneID" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="buttonTwoID" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server">
                        <Columns>
                            //columns code here
    		           </Columns>
    		</asp:GridView>
            </ContentTemplate>
     </asp:UpdatePanel>
