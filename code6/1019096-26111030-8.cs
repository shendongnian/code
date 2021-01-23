    @{
        ViewBag.Title = "Index";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    
    @(Html.Kendo().Grid<ErpMvc.ViewModel.Customer>()
        .Name("Customers")
        .Columns(columns =>
        {
            columns.Bound(c => c.FirstName).Title("First Name");
            columns.Bound(c => c.CustomProperty).Title("Custom Property");
        })
        .Pageable()
        .Sortable()
        .Editable(editable => editable.Mode(GridEditMode.InLine))
        .DataSource(dataSource => dataSource
            .Ajax()
            .Model(model => model.Id(customerID => customerID.CustomerID))
            .Read(read => read.Action("Customers_Read", "Customer"))
            .Update(update => update.Action("Customers_Update", "Customer"))
            .PageSize(50)
         )
    )
