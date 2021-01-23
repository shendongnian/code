    <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" ...>
        Other settings
    </asp:GridView>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            var button = (Button) e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
            button.Enabled = CanCurrentUserViewButton();
        }
    }
    private bool CanCurrentUserViewButton()
    {
        //Logic...
    }
