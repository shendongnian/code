    @model IEnumerable<Webshop.Models.Category>
    <ul>
        @foreach (var category in Model)
        {
            <li>@Html.ActionLink(category.Name, "Category", "Categories", new { ID = category.CategoryID }, null)</li>
    
        }
    </ul>
