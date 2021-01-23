    <asp:GridView ID="GridViewX" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name">
                <ItemStyle Width="150px"/>
            </asp:BoundField>
            <asp:BoundField DataField="Address" HeaderText="Address">
                <ItemStyle Width="50px"/>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewX.DataSource = new List<Custom>
        {
            new Custom {Name = "Jon Doe", Address = "123 Street"},
            new Custom {Name = "Merry Doe", Address = "123 Street"},
        };
        GridViewX.DataBind(); 
    }
    
    public class Custom
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
