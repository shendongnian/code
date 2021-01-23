    @model MvcSiteMapProvider.Web.Html.Models.MenuHelperModel
    @using MvcSiteMapProvider.Web.Html.Models
    <ul class="nav navbar-nav navbar-right">
        @foreach (var node in Model.Nodes) { 
            <li>@Html.DisplayFor(m => node)</li>
        }
    </ul>
