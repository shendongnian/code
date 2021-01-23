    @model MvcSiteMapProvider.Web.Html.Models.MenuHelperModel
    @using MvcSiteMapProvider.Web.Html.Models
    
    <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            @foreach (var node in Model.Nodes) { 
                <li>@Html.DisplayFor(m => node)</li>
            }
        </ul>
        @Html.Partial("_LoginPartial")
    </div>
