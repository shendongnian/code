    @model IEnumerable<WebAdmin.Models.AdminUserViewModel>
    @(Html.Kendo().Grid(Model).Name("adminUsersGrid")
        .Columns(columns =>{
        columns.Bound(item => item.userName);
        columns.Bound(item => item.securityLevel).ClientTemplate("#: securityLevel.levelDescription #" );    
        columns.Bound(item => item.firstName);
        columns.Bound(item => item.lastName);
        columns.Bound(item => item.email);
        columns.Command(command => { command.Edit(); command.Destroy(); });
    })
        .DataSource(dataSource => dataSource
    		.Ajax()
            .Model(m => {
                m.Id(p => p.userID);
                m.Field(item => item.securityLevel).DefaultValue(ViewData["defaultSecurityLevel"] as WebAdmin.Models.SecurityLevelViewModel);
            })
            .Update(u => u.Action("Update", "UserAdmin"))
            .Create(c => c.Action("_Create", "UserAdmin"))
            .Destroy(x => x.Action("_Destroy", "UserAdmin"))
            .Read(read => read.Action("clientIndex", "UserAdmin", new { id = @ViewBag.accountID }))
         )
        .Pageable().Sortable().Filterable()
        .ToolBar(toolbar => toolbar.Create())
        .Editable(e => e.Mode(GridEditMode.PopUp).TemplateName("AdminUserPopup"))
           
    )
