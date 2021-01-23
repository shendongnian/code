      @(Html.Kendo().Grid<Uhrs.Domain.Entities.EntityPermission>()
              .Name("grid_#=FundUserRoleId#") // make sure the Name is unuque
              .Columns(columns =>
              {
                  columns.Bound(p => p.MenuID).Visible(false);
                  columns.Bound(p => p.MenuName).ClientTemplate("<strong>\\#:MenuName\\#</strong>");
                  columns.Bound(p => p.MenuStatus).ClientTemplate("<input type='checkbox' \\#: MenuStatus? checked='checked': checked='' \\# class='chkbx' onclick='checkBoxClick(this,#=FundUserRoleId#)' />");
              })
              .ToolBar(toolbar => toolbar.Save())
              .Editable(editable => editable.Mode(GridEditMode.InCell))
              .HtmlAttributes(new { style = "width:610px;" })
              .DataSource(dataSource =>
                  dataSource
                  .Ajax()
                  .Batch(true)
                  .ServerOperation(false)
                  .PageSize(20)
                  .Model(model =>
                        {
                            model.Id(p => p.MenuID);
                            model.Field(p => p.MenuName).Editable(false);
                        })
                  .Events(events => events.Error("error_handler").RequestEnd("onRequestEndChildGrid"))
                  .Read(read => read.Action("ReadUserPermissions", "Admin", new { linkFundUserId = "#=FundUserRoleId#" }))
                  .Create(create => create.Action("CreateUserPermissions", "Admin", new { linkFundUserId = "#=FundUserRoleId#" }))
                  .Update(update => update.Action("UpdateUserPermissions", "Admin", new { linkFundUserId = "#=FundUserRoleId#", roleID = "#=Role.RoleId#" }))
              )
              .Pageable()
              .ToClientTemplate()
        )
