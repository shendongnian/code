       @(Html.Kendo().Grid(Model.Alarms)
                      .Name("grid")
                      .DataSource(dataSource => dataSource
                          .Ajax()
                          .ServerOperation(false)
                          .Model(m => m.Id(s => s.AlarmComment))
                          .Read(read => read.Action("Alarms_Read", "Alarms", new { id = Model.ViewUnitContract.Id }).Type(HttpVerbs.Get))
                          .AutoSync(true)
                      )
                      .Columns(col =>
                      {
                          col.Bound(p => p.DateOn).Format("{0:u}").Title("Date");
                          col.Bound(p => p.Priority).Width(50);
                          col.Bound(p => p.ExtendedProperty2).Width(100).Title("Action");
                          col.Bound(p => p.AlarmTag).Title("Name");
                          col.Bound(p => p.AlarmComment).Title("Comment");
                          col.Bound(p => p.ExtendedProperty1).Title("AlarmID");
                          col.Bound(x => x.DateOff).Title("Value");
                      })
                      .HtmlAttributes(new {style = "height:430px;"})
    
                      )
