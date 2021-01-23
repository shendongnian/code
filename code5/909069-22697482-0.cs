    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <asp:LinkButton runat="server" Text="PressMe 1" OnClick="ChangePage_Click" CausesValidation="false" CommandArgument="~/Controls/Control1.ascx" />
            <asp:LinkButton runat="server" Text="PressMe 2" OnClick="ChangePage_Click" CausesValidation="false" CommandArgument="~/Controls/Control2.ascx" />
            <asp:PlaceHolder runat="server" ID="placeholder" />
        </ContentTemplate>
    </asp:UpdatePanel>
    protected void Page_Load(object sender, EventArgs e) {
      if (IsPostBack && !string.IsNullOrEmpty(ActiveControl)) {
        placeholder.Controls.Clear();
        placeholder.Controls.Add(LoadControl(ActiveControl));
      }
    }
    protected string ActiveControl {
      get { return (string)ViewState["ActiveControl"]; }
      set { ViewState["ActiveControl"] = value; }
    }
    protected void ChangePage_Click(object sender, EventArgs e) {
      var control = (IButtonControl)sender;
      ActiveControl = control.CommandArgument;
      placeholder.Controls.Clear();
      placeholder.Controls.Add(LoadControl(control.CommandArgument));
    }   
