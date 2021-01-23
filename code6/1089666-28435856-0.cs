    @Html.DropDownListFor(model => model.Business, 
                          new SelectList(
                              new List<Object>{
                                  new { ... },
                                  new { ... },
                                  new { ... }
                              },
                              "value",
                              "text",
                              2),
                          new {
                              @class = "myclass"
                          })
