    @model YourModelTree
         @(Html.Telerik().TreeView()
                      .Name("TelerikTree")
                      .ShowCheckBox(true)
                      .BindTo(Model, mappings =>
                      {
                          mappings.For<YourModelTree>
                              (binding => binding
                                  .ItemDataBound((item, modelItem) =>
                                  {
                                      item.Text = modelItem.Name;
                                      item.Value = modelItem.Id.ToString();
                                      item.Expanded = true;
                                      item.Checked = true;
                                  }).Children(c => c.Children));
                      })))
