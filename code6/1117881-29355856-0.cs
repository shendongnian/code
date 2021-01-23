    @(Html.Kendo().Grid<Kendo.Mvc.Examples.Models.ProductViewModel>()
        .Name("grid")
        .Columns(columns =>
        {
            columns.Bound(p => p.ProductName);
            columns.ForeignKey(p => p.CategoryID, (System.Collections.IEnumerable)ViewData["categories"], "CategoryID", "CategoryName")
                .Title("Category").Width(150);
            columns.Bound(p => p.UnitPrice).Width(150);
            columns.Command(command => command.Destroy()).Width(110);
        })
