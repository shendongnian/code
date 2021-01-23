     @(Html.Kendo().Grid<SomeModel>().Name("grid")
                  .DataSource(src => src.Ajax().Read(read => read.Action("Action", "Controller"))
                  .Columns(col =>
                  {
                      col.Bound(e => e.Name);
                      col.Bound(e => e.Age);
                      col.Bound(e => e.ID);
                  })
                  .Selectable()
                  .Scrollable()
            )
