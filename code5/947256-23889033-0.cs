    @(Html.Kendo().Grid<ToolModel>()
          .Name("grid")
          .Columns(columns =>
          {
              columns.Bound(p => p.Id);
              columns.Bound(p => p.Displace);
              columns.Bound(p => p.FishingNeckOd);
              columns.Bound(p => p.Length);
              columns.Bound(p => p.Model);
              columns.Bound(p => p.Name);
              columns.Bound(p => p.Supplier).Width(150);
              columns.Bound(p => p.TagId);
              columns.Bound(p => p.ToolOd);
              columns.Bound(p => p.Type);
              columns.Bound(p => p.Weight);
              columns.Command(command => { command.Edit(); command.Destroy(); }).Width(180);
          })
          .ToolBar(toolbar => toolbar.Create())
          .Editable(editable => editable.Mode(GridEditMode.PopUp).TemplateName("ToolPopUpTemplate"))
          .Pageable()
          .Sortable()
          .Scrollable()
          .HtmlAttributes(new { style = "height:500px;" })
          .DataSource(dataSource => dataSource
              .Ajax()
              .PageSize(10)
              .Events(events => events.Error("error_handler"))
              .Model(model =>
              {
                  model.Id(toolModel => toolModel.Id);
                  model.Field(id => id.Id).DefaultValue(Guid.NewGuid());
              } )
              .Create(update => update.Action("EditingPopup_Create", "ToolManagement"))
              .Read(read => read.Action("EditingPopup_Read", "ToolManagement"))
              .Update(update => update.Action("EditingPopup_Update", "ToolManagement"))
              .Destroy(destroy => destroy.Action("EditingPopup_Destroy", "ToolManagement"))
          ))
