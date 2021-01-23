    <asp:PlaceHolder runat="server" ID="PlaceHolder1">
        <asp:Panel runat="server" ID="Panel1">
            Panel 1
        </asp:Panel>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="PlaceHolder2">
        <asp:Panel runat="server" ID="Panel2">
            Panel 2
        </asp:Panel>
    </asp:PlaceHolder>
    <asp:Panel runat="server" ID="Panel3">
        Panel 3
    </asp:Panel>
    protected void Page_Load(object sender, EventArgs e)
    {
        string texthi = "Panel1";
    
        var panelControls = FindControlsRecursive<Panel>(Page);
        foreach (var panel in panelControls)
        {
            if (panel.ID.ToUpper() == texthi.ToUpper().Replace(" ", ""))
            {
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }
    }
