    @(Html.Telerik().Grid<YourViewModel>()
    .Name("DocumentGrid")
    .Columns(c =>
    {
    	c.Bound(column => column.SupplierIdentification).Title("CNPJ/CPF");
    	c.Bound(column => column.StatusDescription).Title("Status");                                           
    	c.Bound(column => column.ExpirationDate).Title("Vencimento");
    	c.Bound(column => column.IsStock).Title("Estoque");
    	c.Bound(a => a.IDDocument).Hidden()
    })
    .DataBinding(d => 
    	d.Ajax()
    		.OperationMode(GridOperationMode.Client)
    		.Select("SelectAction", "YourController")
    		.Update("UpdateAction", "YourController")
    		.Insert("InsertAction", "YourController")
    		.Delete("DeleteAction", "YourController")
    	)
    .Pageable(p => p.PageSize(50))
    .Sortable()
    .Scrollable()
    .Groupable()
    .Filterable()
    .KeyboardNavigation()
    .Resizable(r => r.Columns(true))
    .Reorderable(r => r.Columns(true))
    .Editable(e => 
    	e.Mode(GridEditMode.InCell)
    			.DataKeys(k => k.Add(a => a.IDDocument))
    			.ToolBar(c => 
    			{
    				c.Insert();
    				c.SubmitChanges();
    			})
    	)
    )
