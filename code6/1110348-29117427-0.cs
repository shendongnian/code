    <asp:GridView ID="GridView1" runat="server" AllowSorting="true" 
      OnSorting="GridView1_Sorting"> 
    </asp:GridView>
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    { 
        dataTable.DefaultView.Sort = e.SortExpression ;
        GridView1.DataSource = dataTable;
        GridView1.DataBind();
    }
 
