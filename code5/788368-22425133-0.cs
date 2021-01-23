        .Columns(columns =>
        {
            columns.Bound(p => p.ID).Title("ID").Width(100).Visible(false);
            columns.Bound(p => p.Apply).Title("Apply").Width(100);
            columns.Bound(p => p.TaxName).Title("Tax Name").Width(100);
            columns.Bound(p => p.TaxPercent).Title("Percent").Width(130);
            columns.Bound(p => p.OrderApplied).Title("Oreder Applied").Width(130);
            columns.Bound(p => p.Compund).Title("Compund").Width(130);
            columns.Command(command => { command.Edit(); command.Destroy(); }).Width(172);
        })
        .ToolBar(toolbar => toolbar.Create())
        .Editable(editable => editable.Mode(GridEditMode.InLine))
         .Pageable()
        .Sortable()
         .Scrollable(scr=>scr.Height(430)) 
        //.Scrollable(scrollable => scrollable.Virtual(true))
        .HtmlAttributes(new { style = "height:430px;" })
        .Filterable()
        .DataSource(dataSource => dataSource
        .Ajax()
         .PageSize(10)
        .Events(events => events.Error("error_handler"))
        .Model(model => model.Id(p => p.ID))
        .ServerOperation(false)
        .Create(update => update.Action("EditingInline_Create", "Taxes"))
        .Read(read => read.Action("EditingInline_Read", "Taxes"))
        .Update(update => update.Action("EditingInline_Update", "Taxes"))
        .Destroy(update => update.Action("EditingInline_Destroy", "Taxes"))
        )
     )  
