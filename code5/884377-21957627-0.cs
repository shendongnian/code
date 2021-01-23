	<asp:GridView ID="gridView" runat="server" OnRowDataBound="gridView_RowDataBound" OnRowCommand="gridView_Command" AutoGenerateColumns="false" >
		<columns>
			<asp:BoundField DataField="ID" />
			<asp:TemplateField>
				<ItemTemplate>
					<asp:LinkButton ID="lb1" runat="server" Text='<%# Eval("Name") %>' CommandName="NameButton" CommandArgument='<%# Eval("ID") %>' />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="Type" />
		</columns>
	</asp:GridView>
	public void gridView_Command(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "NameButton")
		{
			var id = e.CommandArgument;
			// some code here //
		}
	}
Using this example, you can respond to the event of a click on the "NameButton" only.
