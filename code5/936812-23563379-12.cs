    @model jQuery.Vero.Menu.MvcApplication.Models.MenuItem
    
    <li id="Menu@(Model.MenuItemId)" class="menuItem" data-id="@(Model.MenuItemId)">
        @Model.MenuItemName
        @if (Model.ChildItems.Any())
        {
            <ul class="menu">
                @foreach (var menuItem in Model.ChildItems.OrderBy(x => x.DisplayOrder))
                {
                    @Html.Action("Menu", new { id = menuItem.MenuItemId })
                }
            </ul>
        }
    </li>
