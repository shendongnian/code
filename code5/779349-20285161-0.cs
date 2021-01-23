        //.aspx   
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="ID" DataSourceID="AccessDataSource1"
                        ondatabound="GridView1_DataBound" onrowdatabound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False"
                                ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:BoundField DataField="Location" HeaderText="Location"
                                SortExpression="Location" />
                            <asp:BoundField DataField="ParentID" HeaderText="ParentID"
                                SortExpression="ParentID" />
                            <asp:BoundField DataField="Content" HeaderText="Content"
                                SortExpression="Content" />
                            <asp:BoundField DataField="ShortContent" HeaderText="ShortContent"
                                SortExpression="ShortContent" />
    
    
    //Change the Status Cell Color-----
                            <asp:TemplateField HeaderText="Status" ControlStyle-Width="75px" >
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ParentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
    //--------
    
    
                        </Columns>
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource1" runat="server"
                        DataFile="App_Data/Database1.accdb" SelectCommand="SELECT CMSMenus.ID, CMSMenus.Title, CMSMenus.Location, CMSMenus.ParentID, CMSMenus.Content, CMSMenus.ShortContent
                FROM CMSMenus;
                ">
                    </asp:AccessDataSource>
            
            
            
            //C#
            
            protected void GridView1_DataBound(object sender, EventArgs e)
                {
                    for (int i =0 ; i <= GridView1.Rows.Count -1 ;i++)
                    {
                        Label lblparent = (Label)GridView1.Rows[i].FindControl("Label1");//Get ParentID
            
                        if (lblparent.Text == "1")
                        {
                            GridView1.Rows[i].Cells[6].BackColor = Color.Yellow;
                            lblparent.ForeColor = Color.Black;
                        }
                        else
                        {
                            GridView1.Rows[i].Cells[6].BackColor = Color.Green;
                            lblparent.ForeColor = Color.Yellow;
                        }
                            
                    }
                }
