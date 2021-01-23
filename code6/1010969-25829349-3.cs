    <asp:ScriptManager runat="server" />
            <h1>Board Games (using Update Panel)</h1>
            <asp:Timer runat="server" ID="UP_Timer" Interval="5000" />
            <asp:UpdatePanel runat="server" ID="Game_UpdatePanel">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="UP_Timer" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                    <asp:Repeater runat="server" ID="BoardGameRepeater" ItemType="RealTimeDemo.Models.BoardGame">
                        <HeaderTemplate>
                            <table border="1">
                                <tr>
                                    <th>Id</th>
                                    <th>Name</th>
                                    <th>Description</th>
                                    <th>Quantity</th>
                                    <th>Price</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#: Item.Id %></td>
                                <td><%#: Item.Name %></td>
                                <td><%#: Item.Description %></td>
                                <td><%#: Item.Quantity %></td>
                                <td><%#: Item.Price %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate></table></FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
            
