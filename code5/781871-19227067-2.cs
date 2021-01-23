    <telerik:RadGrid ID="RadGrid1" Skin="Black" runat="server" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource1">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="Subject" HeaderText="Subject">
                </telerik:GridBoundColumn>
            </Columns>
            <RowIndicatorColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
        </MasterTableView>
    </telerik:RadGrid>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send email - grid" />
    protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        List<MailMessage> mList = new List<MailMessage>();
        MailMessage m1 = new MailMessage();
        m1.Subject = "One";
        mList.Add(m1);
        MailMessage m2 = new MailMessage();
        m2.Subject = "Two";
        mList.Add(m2);
        MailMessage m3 = new MailMessage();
        m3.Subject = "Three";
        mList.Add(m3);
        RadGrid1.DataSource = mList;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string GridRawHtml;
        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter clearWriter = new HtmlTextWriter(stringWriter);
        RadGrid1.RegisterWithScriptManager = false;
        RadGrid1.RenderControl(clearWriter);
        GridRawHtml = clearWriter.InnerWriter.ToString();
        GridRawHtml = GridRawHtml.Remove(GridRawHtml.IndexOf("<script"), GridRawHtml.LastIndexOf("</script>") - GridRawHtml.IndexOf("<script"));
        Response.Write(GridRawHtml);
    }
