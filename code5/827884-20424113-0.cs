    public partial class SomeClass
    {
        private TextBox _textBox;
        protected void Page_Init(object sender, EventArgs e)
        {
            _textBox = new TextBox { EnableViewState = true };
            _textBox.TextChanged += (o, args) =>
                                        {
                                        };
            Wrapper.Controls.Add(_textBox);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                _textBox.Text = "Initial Text";
            }
            else
            {
                // Loaded from viewstate, yay.
            }
        }
    }
    <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="server">
        <asp:Panel runat="server" ID="Wrapper"/>
        <asp:Button runat="server" Text="PostBack!"/>
    </asp:Content>
