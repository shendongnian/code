    public partial class _Default : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            fillGrid();
        }
        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public double UnitPrice { get; set; }
        }
        public void fillGrid()
        {
            var ListProduct = new List<Product>();
            ListProduct.Add(new Product() { ID = 1, Name = "item1", UnitPrice = 4.5 });
            ListProduct.Add(new Product() { ID = 1, Name = "item1", UnitPrice = 4.5 });
            ListProduct.Add(new Product() { ID = 1, Name = "item1", UnitPrice = 4.5 });
            ListProduct.Add(new Product() { ID = 1, Name = "item1", UnitPrice = 4.5 });
            GridView1.DataSource = ListProduct;
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {     
            int Dozen = 12;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Product row = ((Product)e.Row.DataItem);
                double UnitPrice = row.UnitPrice;
                ((Literal)e.Row.FindControl("ltrDozenPrice")).Text = Convert.ToString(UnitPrice * Dozen);
            }
        }    
    }
 
----------
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
            <asp:TemplateField HeaderText="DozenPrice">
                <ItemTemplate>
                    <asp:Literal ID="ltrDozenPrice"  runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
