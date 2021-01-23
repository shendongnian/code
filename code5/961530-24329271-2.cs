    <asp:Button ID="Button1" runat="server" Text="SubmitButton" 
        OnClick="SubmitButton_Click" />
    <asp:GridView ID="Add" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="100px">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    public class SampleClass
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Add.DataSource = new List<SampleClass>()
            {
                new SampleClass {Id = 1, Text = "One"},
                new SampleClass {Id = 2, Text = "Two"},
            };
            Add.DataBind();
        }
    }
    
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in Add.Rows)
        {
            var textbox = row.FindControl("TextBox") as TextBox;
            var a = textbox.Text;
        }
    }
