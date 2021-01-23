    <div>
        <asp:Button ID="btnBind" runat="server" Text="Bind" OnClick="btnBind_Click" />
        <asp:CheckBoxList ID="cbList" runat="server"></asp:CheckBoxList>
    </div>
    public partial class _Default : Page
    {
        protected void btnBind_Click(object sender, EventArgs e)
        {
            List<CheckboxItem> listCheckboxItems = new List<CheckboxItem>();
            listCheckboxItems.Add(new CheckboxItem("Val-1", "Item-1"));
            listCheckboxItems.Add(new CheckboxItem("Val-2", "Item-2"));
            listCheckboxItems.Add(new CheckboxItem("Val-3", "Item-3"));
            listCheckboxItems.Add(new CheckboxItem("Val-4", "Item-4"));
            listCheckboxItems.Add(new CheckboxItem("Val-5", "Item-5"));
            this.cbList.DataSource = listCheckboxItems;
            this.cbList.DataValueField = "Value";
            this.cbList.DataTextField = "Text";
            this.cbList.DataBind();
        }
    }
    [Serializable]
    public class CheckboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public CheckboxItem(string value, string text)
        {
            Value = value;
            Text = text;
        }
        public override string ToString()
        {
            return "brompot";
        }
    }
