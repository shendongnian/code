        <asp:GridView ID="GridView1" runat="server" onselectedindexchanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="false">   
        <Columns>
          <asp:BoundField DataField="Group Name" HeaderText="Group Name" />
          <asp:BoundField DataField="User" HeaderText="User" />
          <asp:BoundField DataField="Section" HeaderText="Section" />
          <asp:TemplateField HeaderText="Action" ShowHeader="true" HeaderStyle-HorizontalAlign="Center" Visible="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="#ad0015">
       <ItemTemplate>
          <asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" Width="100px"/>
          </ItemTemplate> 
          </asp:TemplateField>
        <asp:TemplateField HeaderText="">
        <HeaderTemplate>
          </HeaderTemplate>
          </asp:TemplateField>
          </Columns>
          </asp:GridView>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Ok" 
          Width="119px" />
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = GetData();
        if (!Page.IsPostBack)
        {
            GridView1.DataBind();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    DataTable GetData()
    {
        SPSite oSiteCollection = SPContext.Current.Site;
        SPWeb oWeb = oSiteCollection.OpenWeb();
        SPList oSPList = oWeb.Lists["sample"];
        SPListItemCollection oSPListItemCollection = oSPList.Items;
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("Group Name", typeof(String));
            dt.Columns.Add("User", typeof(String));
            dt.Columns.Add("Section", typeof(String));
            dt.Columns.Add("Active", typeof(bool));
            dt.Columns.Add("ID", typeof(int));
            DataRow dataRow;
            foreach (SPListItem oSplistItem in oSPListItemCollection)
            {
                dataRow = dt.Rows.Add();
                dataRow["Group Name"] = oSplistItem["Group Name"].ToString();
                dataRow["User"] = oSplistItem["User"].ToString();
                dataRow["Section"] = oSplistItem["Section"].ToString();
                dataRow["ID"] = oSplistItem["ID"];
                dataRow["Active"] = oSplistItem["Active"].ToString();
            }
            return dt;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Managers Approval" + ex.Message.ToString());
            return dt;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("chkStatus");
            bool status = cb.Checked;
            string strBoolean = Convert.ToString(status);
                    if (cb != null)
                    {
                        SPSite oSiteCollection = SPContext.Current.Site;
                        using (SPWeb oWeb = oSiteCollection.OpenWeb())
                        {
                            SPList oSPList = oWeb.Lists["sample"];
                            SPListItemCollection oSPListItemCollection = oSPList.Items;
                            //foreach (SPListItem oSplistItem in oSPListItemCollection)
                            //{
                             int rowId = Int32.Parse(grdList.DataKeys[dr.RowIndex].Value.ToString());
                               
                             SPListItem oSplistItem = oSPList.GetItemById(Convert.ToInt32(rowId));
                              oWeb.AllowUnsafeUpdates = true;
                               {
                                if (strBoolean == "True")
                                {
                                    oSplistItem["Active"] = true;
                                }
                                else
                                {
                                    oSplistItem["Active"] = false;
                                }
                                oSplistItem.Update();
                            }
                              oWeb.AllowUnsafeUpdates = false;
                        }
        }
}
