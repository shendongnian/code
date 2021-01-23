    @Html.Grid(Model).Named("UsersGrid").Columns(columns =>
    		{
    			columns.Add(c => c.ID).Titled("ID");
    			columns.Add(c => c.cardType).Titled("Card Type")
    			.RenderValueAs(c => CustomRenderingOfColumn(c));
    
    		}).WithPaging(10).Sortable(true)
