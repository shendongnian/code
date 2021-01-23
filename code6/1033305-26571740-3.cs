    @(Html.Kendo().Grid<GridViewModel>()
          .Name("myGrid")
          .Columns(columns =>
          {
              columns.Bound(m => m.myDateProperty_filter).ClientTemplate("#= myDateProperty #");
          })
          .Sortable()
          .DataSource(dataSource => dataSource
              .Ajax()
              .Sort(s => s.Add("myDateProperty_filter").Descending())
              .Model(model => model.Id(a => a.Id))
              .ServerOperation(false)
                  .Read("myMethod", "myController"))
