    Html.Kendo().Grid<Models.Environment>()
                       .Name("environmentGrid")
                       .Sortable()
                       .ToolBar(tb =>  tb.Create())
                       .Editable(editable => editable.Mode(GridEditMode.PopUp))
                       .Columns(cols =>
                       {
                           cols.Bound(c => c.Name).Width(150).Sortable(true);
                           cols.Bound(c => c.ConnectionString).Width(150).Sortable(true);
                           cols.Bound(c => c.Template).Width(150).Sortable(true);
                           cols.Bound(c => c.isDefault).Width(150).Sortable(true);
                           cols.Bound(c => c.StatusID).Width(150).Sortable(true);
                           cols.Command(command => { command.Edit();}).Width(60);
                       })
                       .DataSource(ds => ds
                           .Ajax()
                           .Model(model => 
                           { 
                               model.Id(m => m.EnvironmentID);
                           })
                           .Events(events =>
                                  {
                                        events.RequestEnd("onRequestEnd"); //I've added this
                                  })
                               .Read(r => r.Action("GetEnvironments", "Admin"))
                               .Update(update => update.Action("UpdateEnvironments", "Admin"))
                               .Create(update => update.Action("UpdateEnvironments", "Admin"))                           
                           )
