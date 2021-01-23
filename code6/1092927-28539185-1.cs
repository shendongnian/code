    <div class="table">
        @(Html.Kendo().Grid<COGS.Models.WayBill>()
        .Name("grid")
        .DataSource(DataSource => DataSource
            .Ajax()
            .PageSize(100)
            .Model(model => model.Id(data => data.WaybillNumber))
            .Read(read => read.Action("Read", "Home").Data("addSearch"))
            .Sort(sort => sort.Add(product => product.ETA).Descending())
        )
        .Columns(columns =>
                {
                    columns.Template(
                        @<text>
                            @Html.ActionLink(@item.WaybillNumber, "home", "details", new { id = @item.WaybillNumber })
                        </text>
                    ).ClientTemplate("<a href='home/details/#=WaybillNumber#'>#=WaybillNumber#</a>").Title("Waybill");
                    columns.ForeignKey(data => data.ShipmentID, (System.Collections.IEnumerable)ViewData["shipment"], "ShipmentID", "Content").Title("Shipmnet Type");
                    columns.ForeignKey(data => data.CurrencyID, (System.Collections.IEnumerable)ViewData["currency"], "CurrencyID", "Content").Title("Currency");
                    columns.Bound(data => data.Description);
                    columns.Bound(data => data.ETD).EditorTemplateName("Date").Format("{0:MM/dd/yyyy}");
                    columns.Bound(data => data.ETA).EditorTemplateName("Date").Format("{0:MM/dd/yyyy}");
                    columns.Bound(data => data.PIB_Date).EditorTemplateName("Date").Format("{0:MM/dd/yyyy}").Title("PIB Date");
                    columns.Bound(data => data.PIB_PaymentDate).EditorTemplateName("Date").Format("{0:MM/dd/yyyy}").Title("PIB Payment Date");
                }
        )
        .Pageable()
        .Sortable()
        )
    </div>
