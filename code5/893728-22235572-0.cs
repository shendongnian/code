       <asp:GridView ID="yourGrid" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="YourSource" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="YourCheckBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    protected void btnClick_Click(object sender, EventArgs e)
    { 
   
    foreach (GridViewRow row in gridview1.Rows)
    {
        CheckBox chk = (CheckBox)row.FindControl("chk");
        if (((CheckBox)row.FindControl("chk")).Checked)
        {
            do all your stuff here.
           //------
        }
    }
   }
