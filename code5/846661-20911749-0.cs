    <asp:SqlDataSource ID="dsIAMS" runat="server" ConnectionString="<%$ ConnectionStrings:ReportsConnectionString %>" />
    dl = (DropDownList)tFilters.Controls[0];
    // dl.ID = dlPASUBTYPENAME 
    if (dl.SelectedItem.Text == "") {
      dsIAMS.SelectCommand+=dl.ID.Substring(2) + " IS NULL";
    }
    else {
      dsIAMS.SelectCommand+=dl.ID.Substring(2) + "='" + dl.SelectedItem.Text + "'";
    }
