    @(Html.Kendo().Grid<Kendo.Mvc.Examples.Models.Discount>()
    .Name("discountgrid")
    .Columns(c=>
    {
        c.Bound(d => d.Id);
        c.Bound(d => d.Category);
        c.Bound(d => d.Percentage);
        c.Bound(d => d.Merchandise);
        c.Command(cm => { cm.Edit(); cm.Destroy(); });
    })
    .Pageable()
    .ToolBar(toolbar => toolbar.Create())
    .Editable(editable => editable.Mode(GridEditMode.InCell))
    .DataSource(dataSource => dataSource
        .Ajax()
        .PageSize(3)
        .ServerOperation(false)
        .Events(e => { e.RequestEnd("onRequestEnd"); })//onRequestEnd is the javascript fxn
        .Model(model => model.Id(d => d.Id))
        .Read(read => read.Action("EditingInline_Read","Grid"))
        .Create(update => update.Action("EditingInline_Create", "Grid"))
        .Update(update => update.Action("EditingInline_Update", "Grid"))
        .Destroy(update => update.Action("EditingInline_Destroy", "Grid"))
    ))
    <script type="text/javascript">
    function onRequestEnd(e) {
        if (e.type === "create" || e.type === "update" || e.type === "destroy") {
            e.sender.read();
        }
    }
    </script>
