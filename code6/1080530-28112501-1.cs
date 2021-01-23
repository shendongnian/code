    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="gview">
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="700px" ScrollBars="Both" Height="330px">
                <asp:TabPanel runat="server" HeaderText="Cardiology" ID="TabPanel1">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CID" DataSourceID="SqlDataSource1">
                            <Columns>
      //auto generated columns                          
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:TabPanel>
            </TabContainer>
         </div>
     </asp:Content>
