    <script>
        function addAllItems() {
            $("#<%= lbAvail.ClientID %> option").appendTo("#<%= lbSelected.ClientID %>");
            enableControls();
        }
    
        function addSelectedItems() {
            $("#<%= lbAvail.ClientID %> option:selected").appendTo("#<%= lbSelected.ClientID %>");
            enableControls();
        }
    
        function removeAllItems() {
            $("#<%= lbSelected.ClientID %> option").appendTo("#<%= lbAvail.ClientID %>");
            enableControls();
        }
    
        function removeSelectedItems() {
            $("#<%= lbSelected.ClientID %> option:selected").appendTo("#<%= lbAvail.ClientID %>");
            enableControls();
        }
    
        function enableButtons(listBoxControlId, buttonAllControlId, buttonSelectedContolId) {
            var count = $("#" + listBoxControlId + " option").length;
            document.getElementById(buttonAllControlId).disabled = count <= 0;
            count = $("#" + listBoxControlId + " option:selected").length;
            document.getElementById(buttonSelectedContolId).disabled = count <= 0;
        }
    
        function enableControls() {
            enableButtons("<%= lbAvail.ClientID %>", "<%= btnAddAll.ClientID %>", "<%= btnAddSelected.ClientID %>");
            enableButtons("<%= lbSelected.ClientID %>", "<%= btnRemoveAll.ClientID %>", "<%= btnRemoveSelected.ClientID %>");
        }
    
        function selectAll() {
            $("#<%= lbSelected.ClientID %> option").prop("selected", true);
        }
    </script>
    
    <div style="margin-top: 20px;">
        <table>
            <tr>
                <td>
                    <asp:ListBox ID="lbAvail" runat="server" style="min-width: 150px" Height="150" SelectionMode="Multiple" 
                                 onchange="enableControls();" ondblclick="addSelectedItems();"/>
                </td>
                <td style="padding-left: 10px; padding-right: 10px;">
                    <table>
                        <tr>
                            <td>
                                <asp:Button Width="35" ID="btnAddAll" Text="&raquo;" OnClientClick="addAllItems(); return false;" UseSubmitBehavior="False" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 5px">
                                <asp:Button Width="35" ID="btnAddSelected" Text=">" OnClientClick="addSelectedItems(); return false;" UseSubmitBehavior="False" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 5px">
                                <asp:Button Width="35" ID="btnRemoveSelected" Text="<" OnClientClick="removeSelectedItems(); return false;" UseSubmitBehavior="False" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 5px">
                                <asp:Button Width="35" ID="btnRemoveAll" Text="&laquo;" OnClientClick="removeAllItems(); return false;" UseSubmitBehavior="False" runat="server"/>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:ListBox ID="lbSelected" runat="server" style="min-width: 150px" Height="150" SelectionMode="Multiple"
                                 onchange="enableControls();" ondblclick="removeSelectedItems();"/>
                </td>
            </tr>
        </table>
        
        <div style="margin-top: 10px;">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" runat="server" OnClientClick="selectAll();"/>
        </div>
    </div>
...
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbAvail.Items.Add(new ListItem("Monday", "Mon"));
            lbAvail.Items.Add(new ListItem("Tuesday", "Tues"));
            lbAvail.Items.Add(new ListItem("Wednesday", "Wed"));
            lbAvail.Items.Add(new ListItem("Thursday", "Thur"));
            lbAvail.Items.Add(new ListItem("Friday", "Fri"));
            lbAvail.Items.Add(new ListItem("Saturday", "Sat"));
            lbSelected.Items.Add(new ListItem("Sunday", "Sun"));
            ScriptManager.RegisterStartupScript(this, GetType(), "CallEnableControls", "enableControls()", true);
        }
        else
        {
            string[] selectedValues = Request.Form.GetValues(lbSelected.UniqueID);
            // ...
        }
    }
    
    protected override void Render(HtmlTextWriter writer)
    {
        // Register all Available items as valid items in the Selected listbox.
        foreach (ListItem item in lbAvail.Items)
        {
            ClientScript.RegisterForEventValidation(lbSelected.UniqueID, item.Value);
        }
        // When a user removes an item from the Selected listbox, we put it into the
        // Available listbox, so we have to register it here, or we'll get an error.
        foreach (ListItem item in lbSelected.Items)
        {
            ClientScript.RegisterForEventValidation(lbAvail.UniqueID, item.Value);
        }
    
        base.Render(writer);
    }
