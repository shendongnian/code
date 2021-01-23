    @(Html.Kendo().Grid<OtpadModel.AddressObject>()
    .Name("Grid")
    .Pageable()
    .Sortable()
    .Selectable(sel =>
    {
            sel.Mode(GridSelectionMode.Single);
    })
    .AutoBind(false)
    .Filterable()
    .Scrollable()
    .Events(events => events.Change("onChange"))
    .Groupable()
    .DataSource(dataSource => dataSource
        .Ajax()
        .Read(read => read.Action("GetAddressObjects", "AddressObject"))
        .Model(model => model.Id(p => p.ID)))
    .Columns(columns => {
        columns.Bound(p => p.KeyNumber).Title("Šifra objekta");
        columns.Bound(p => p.ObjectType.Type).Title("Vrsta objekta");
        columns.Bound(p => p.ObjectOwners.FirstOrDefault().Owner.Name).Title("Ime vlasnika");
        columns.Bound(p => p.ObjectOwners.FirstOrDefault().Owner.Surname).Title("Prezime vlasnika");
        columns.Bound(p => p.Address.Street).Title("Ulica");
        columns.Bound(p => p.Address.Number).Title("Broj");
        columns.Bound(p => p.Address.City.Name).Title("Grad");
        columns.Bound(p => p.ResidentalArea).Title("Površina");
        columns.Bound(p => p.ResidentsNumber).Title("Članovi");
        columns.Bound(p => p.TuristBedsNumber).Title("Turistički kreveti");
    })   
