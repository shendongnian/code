    <asp:Table ID="myAspTable" runat="server" />
    
    protected void Page_Load(object sender, EventArgs e)
    {
        int n = 3;
    
        for (int i = 0; i < n; i++)
        {
            var checkBox = new CheckBox();
            var textBox = new TextBox();
    
            var tblrow = new TableRow();
            var tblcell = new TableCell();
            tblcell.Controls.Add(checkBox);
            tblcell.Controls.Add(textBox);
            tblrow.Controls.Add(tblcell);
            myAspTable.Controls.Add(tblrow);
    
            checkBox.AutoPostBack = true;
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
        }
    }
    
    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        var checkbox = sender as CheckBox;
    
        var textbox = checkbox.Parent.Controls.OfType<TextBox>()
            .Select(control => control)
            .FirstOrDefault();
    
        if (textbox != null)
        {
            string value = textbox.Text;
        }
    }
