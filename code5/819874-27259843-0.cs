    @model MvcSiteMapProvider.Web.Html.Models.MenuHelperModel
    @using MvcSiteMapProvider.Web.Html.Models
    @foreach (var node in Model.Nodes)
    {
       <li @((node.IsCurrentNode || node.Children.Any(n => n.IsCurrentNode)) ? "class=active" : "")>@Html.DisplayFor(m => node)</li>  
    }
