    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="CustomersGridView_RowDataBound" DataKeyNames="storyid" DataSourceID="yourdatasource">
    <Columns>
    <asp:BoundField DataField="StoryData" HeaderText="StoryData" InsertVisible="False" ReadOnly="True" SortExpression="StoryData" />
    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
    </Columns>
    </asp:GridView>
    <script runat="server">
        void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                HyperLink link = new HyperLink();
                link.Text = e.Row.Cells[1].Text.ToString();
                link.NavigateUrl = @"ReaderPage.aspx?StoryTitle=" + e.Row.Cells[1].Text.ToString();
                link.Attributes.Add("onmouseover", "this.style.backgroundColor='red'");
                link.Attributes.Add("onmouseout", "this.style.backgroundColor='#E9EDF1'");
                link.Target = "_blank";
                e.Row.Cells[1].Controls.Add(link);
            }
        }
    </script>
