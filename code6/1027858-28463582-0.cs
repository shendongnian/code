	<asp:GridView ID="GridView_History" runat="server">
		<PagerTemplate>
				<asp:LinkButton ID="lnkPrev" runat="server" CommandName="Page" CommandArgument="Prev">Prev</asp:LinkButton>
				<asp:Repeater ID="rptPagesHistory" OnItemDataBound="rptPagesHistory_ItemDataBound" runat="server" OnLoad="rptPagesHistory_Load">
					<ItemTemplate>
						<asp:LinkButton ID="lnkPageNumber" CommandName="Page" runat="server" OnClick="lnkPageNumberHistory_Click" />
					</ItemTemplate>
				</asp:Repeater>
				<asp:LinkButton ID="lnkNext" runat="server" CommandName="Page" CommandArgument="Next">Next</asp:LinkButton>
		</PagerTemplate>
	</asp:GridView>
	
	protected void rptPagesHistory_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		LinkButton lnkPageNumber = new LinkButton();
		System.Int32 pageNumber = (System.Int32)e.Item.DataItem;
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
		{
			lnkPageNumber = (LinkButton)e.Item.FindControl("lnkPageNumber");
			lnkPageNumber.Text = pageNumber;
			lnkPageNumber.CommandArgument = pageNumber - 1;
		}
	}
	protected void rptPagesHistory_Load(object sender, EventArgs e)
	{
		Repeater rpt = (Repeater)sender;
		rpt.DataSource = Enumerable.Range(1, GridView_History.PageCount);
		rpt.DataBind();
	}
	protected void lnkPageNumberHistory_Click(object sender, EventArgs e)
	{
		LinkButton btn = (LinkButton)sender;
		GridView_History.PageIndex = btn.CommandArgument;
		GridView_History.DataBind();
	}
