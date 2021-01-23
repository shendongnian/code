                          .Columns(columns =>
                          {
                              columns.Bound(c => c.Make).Width(180);
                              columns.Bound(c => c.ModelNo).Width(280);
                              columns.Bound(c => c.EngineSize).Width(120);
                              columns.Bound(c => c.Colour).Width(65);
                              columns.Bound(c => c.MPG).Width(65);
                              columns.Bound(c => c.CarId)
                                  .Title("Include in Report")
                                  .ClientTemplate("<input type=\"checkbox\" name=\"selectedIds\" value=\"#=CarId#\" class=\"checkboxClass\" />")
                                      .Width(90)
                                      .Sortable(false); 
    // added code here...
                              if(Model.FuelType == "Petrol")
                                  columns.Bound(c => c.NumberSparkPlugs).Width(65);
                              else
                                  columns.Bound(c => c.Torque).Width(65);
                          })
