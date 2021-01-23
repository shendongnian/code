    @model IEnumerable<Kendo.Mvc.Examples.Models.Product>
      
    @helper ThirdLevelHelper(Kendo.Mvc.Examples.Models.Product x)
    {
         
          @(Html.Kendo().Grid(Model)    
            .Name("Grid"+Guid.NewGuid())
            .Columns(columns => {
                columns.Bound(p => p.ProductID).Groupable(false);
                columns.Bound(p => p.ProductName);
                columns.Bound(p => p.UnitPrice);
                columns.Bound(p => p.UnitsInStock);
            })
            .Pageable()
            .Sortable()
            .Scrollable() 
            .Filterable()
            .Groupable()
        )
    }
    
    @(Html.Kendo().Grid(Model)    
        .Name("Grid")
        .Columns(columns => {
            columns.Bound(p => p.ProductID).Groupable(false);
            columns.Bound(p => p.ProductName);
            columns.Bound(p => p.UnitPrice);
            columns.Bound(p => p.UnitsInStock);
        })
        .DetailTemplate(@<text>
    @(Html.Kendo().Grid(Model)    
        .Name("Grid"+item.ProductID)
        .Columns(columns => {
            columns.Bound(p => p.ProductID).Groupable(false);
            columns.Bound(p => p.ProductName);
            columns.Bound(p => p.UnitPrice);
            columns.Bound(p => p.UnitsInStock);
        })
        .DetailTemplate(x=>ThirdLevelHelper(x))
        .Pageable()
        .Sortable()
        .Scrollable() 
        .Filterable()
        .Groupable()
    )
    </text>)
        .Pageable()
        .Sortable()
        .Scrollable() 
        .Filterable()
        .Groupable()
    )
