    @model Tuple<WebApplication1.Models.Navigation, WebApplication1.Models.Contents>
    <ul class="nav sf-menu clearfix">
        @foreach (var item in Model.Item1)
        {
            @Html.MenuLink(item.Title, item.Action, item.Controller)
            <ul>
            @foreach (var item in Model.Item2)
                {
                    @Html.MenuLink(item.Title, "Article", "Home")
                }
            </ul>
        }
    </ul>
