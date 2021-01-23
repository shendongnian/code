    @model MVC5Empty.Models.TestModel
    @{
        ViewBag.Title = "Test";
    }
    
    <h2>Test</h2>
    
    <ul>
        @foreach (var item in Model.Items)
        {
            <li>@item.Item1 -- @Html.DropDownList(item.Item1 + "ddlvalue", Model.Items.Where(i => i.Item1 <= item.Item1).Select(i => new SelectListItem() { Text = i.Item2, Value = i.Item2 }))</li>
        }
    </ul>
