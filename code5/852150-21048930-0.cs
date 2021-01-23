    <asp:GridView ID="GridView1" Width="100%" AutoGenerateSelectButton="false" runat="server" AllowPaging="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Customer Type">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="button1" Text='<%#Eval("TenLop") %>' OnClick="Button1_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
