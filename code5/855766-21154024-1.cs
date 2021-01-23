    <asp:DropDownList ID="dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged1">
                <asp:ListItem Text="---Select amount" Selected="True" Value="0"></asp:ListItem>
                <asp:ListItem Text="Master card" Value="1"></asp:ListItem>
                <asp:ListItem Text="Maestro" Value="2"></asp:ListItem>
                <asp:ListItem Text="Visa" Value="3"></asp:ListItem>
                <asp:ListItem Text="Visa Debit" Value="4"></asp:ListItem>
                <asp:ListItem Text="Post office Credit card" Value="5"></asp:ListItem>
            </asp:DropDownList>
            <asp:MultiView ID="multiview" ActiveViewIndex="0" runat="server">
                <asp:View ID="viewtext" runat="server">
                    <p>
                        Default View
                    </p>
                </asp:View>
                <asp:View ID="view1" runat="server">
                    <p>
                     Master card
                    </p>
                </asp:View>
                <asp:View ID="view2" runat="server">
                    <p>
                       Maestro
                    </p>
                </asp:View>
                <asp:View ID="view3" runat="server">
                    <p>
                        Visa
                    </p>
                </asp:View>
                <asp:View ID="view4" runat="server">
                    <p>
                        Visa Debit
                    </p>
                </asp:View>
                <asp:View ID="view5" runat="server">
                    <p>
                       Post office Credit card
                    </p>
                </asp:View>
            </asp:MultiView>
