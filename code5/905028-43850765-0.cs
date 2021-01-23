     @(Html.Kendo().Grid<Model>()
                      .Columns(columns =>
                      {
                          columns.Bound(p => p.ItemName);
                          columns.Bound(p => p.Qty);
                          columns.Bound(p => p.Price);
                          columns.Bound(p => p.Total);
                          
                          columns.Command(command =>
                          {
                              command.Edit();
                          })
                      })
                      .Editable(editable => editable.Mode(GridEditMode.InLine))
                      
                      .DataSource(dataSource => dataSource 
                          .Ajax()
                          .Model(model =>
                          {
                              model.Id(x => x.ExchangeRateId);
                              model.Field(x => x.Total).Editable(false);
                              
                          })
                          .Read(read => read.Action("Read", "Products"))
                          .Update(update => update.Action("Update", "Products"))
                     )
                )
