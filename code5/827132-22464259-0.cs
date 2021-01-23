    @{
        ViewBag.Title = "Contacts";
        var customerId = ViewContext.RouteData.Values["id"];
    }
    <h2>@ViewBag.Title</h2>
    @(
    Html.Kendo()
        .Grid<Fss.Areas.Customers.Models.Contact>()
        .Name("contacts")
        .Columns(columns =>
        {
            columns.Bound(c => c.Active).ClientTemplate("<input type=\"checkbox\" disabled=\"disabled\" value=\"#= ContactId #\" # if (Active) { #checked='checked'# } #/>");
            columns.Bound(c => c.LastName);
            columns.Bound(c => c.FirstName);
            columns.Bound(c => c.Email);
            columns.Bound(c => c.Phone);
            columns.Bound(c => c.Mobile);
            columns.Bound(c => c.Changed).Format("{0:HH:mm:ss d/M/yyyy}");
            columns.Bound(c => c.ChangedBy);
            columns.Command(command =>
            {
                command.Edit();
                command.Destroy();
            }).Width(172);
        })
        .ToolBar(toolbar =>
        {
            toolbar.Template(@<text>
                @item.CreateButton()
                <div class="toolbar">
                @Html.Label("Customer", new { @class = "customer-label" })
                @(Html.Kendo()
                      .DropDownList()
                      .Name("customers")
                      .DataTextField("Name")
                      .DataValueField("CustomerId")
                      .AutoBind(true)
                      .Events(e => e.Change("changeCustomer"))
                      .Value(customerId.ToString())
                      .DataSource(source => source.Read(read => read.Action("GetCustomers", "Contacts")))
                )
                </div>
                </text>);
        })
        .Editable(editable => editable.Mode(GridEditMode.PopUp))
        .Pageable(pageable => pageable.ButtonCount(5))
        .Sortable(sortable => sortable.AllowUnsort(true).SortMode(GridSortMode.MultipleColumn))
        .Scrollable()
        .Filterable()
        .Reorderable(con => con.Columns(true))
        .Resizable(con => con.Columns(true))
        .ColumnResizeHandleWidth(5)
        .HtmlAttributes(new { style = "height:600px;" })
        .Events(e => e.Edit("edit"))
        .DataSource(dataSource => dataSource.Ajax()
                                            .PageSize(10)
                                            .Events(events => events.Error("error_handler"))
                                            .Model(model =>
                                            {
                                                model.Id(c => c.ContactId);
                                                model.Field(f => f.CustomerId).Editable(false);
                                                model.Field(f => f.Changed).Editable(false);
                                                model.Field(f => f.ChangedBy).Editable(false);
                                                model.Field(f => f.Error).Editable(false);
                                            })
                                            .Filter(filter => filter.Add(c => c.CustomerId.ToString() == customerId.ToString()))
                                            .Create(c => c.Action("Create", "Contacts").Data("getCustomerId"))
                                            .Read(r => r.Action("Read", "Contacts"))
                                            .Update(u => u.Action("Edit", "Contacts"))
                                            .Destroy(d => d.Action("Delete", "Contacts")))
    )
    <style scoped="scoped">    
        #contacts .k-toolbar
        {
            min-height: 27px;
            padding: 1.3em;
        }
    
        .customer-label
        {
            vertical-align: middle;
            padding-right: .5em;
        }
    
        .toolbar
        {
            float: right;
        }
    </style>
    <script type="text/javascript">
        function getCustomerId() {
            return {id:$("#customers").val()};
        }
        function changeCustomer(e) {
            var value = this.value(), grid = $("#contacts").data("kendoGrid");
    
            if (value) {
                grid.dataSource.filter({ field: "CustomerId", operator: "eq", value: parseInt(value) });
            }
            else {
                grid.dataSource.filter({});
            }
        }
        function edit(e) {        
            $.each(["Changed", "ChangedBy", "Error", "ContactId", "CustomerId"], function (index, value) {
                e.container.find("label[for='" + value + "']").parent().attr("style", "display:none;");
                e.container.find("input[name='" + value + "']").parent().attr("style", "display:none;");
            });
        }
    </script>
    @Scripts.Render("~/bundles/editing")
