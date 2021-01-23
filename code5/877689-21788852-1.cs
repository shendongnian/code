    // MyMenu.cshtml
    @* // This template is for the root level *@
    @model MvcSiteMapProvider.Web.Html.Models.MenuHelperModel
    @using System.Web.Mvc.Html
    @using MvcSiteMapProvider.Web.Html.Models
    
    <ul id="menu">
        @foreach (var node in Model.Nodes) { 
            <li>@Html.DisplayFor(m => node, "MyMenuNode") @* <-- // Custom Node Helper Name *@
                @if (node.Children.Any()) {
                    @Html.DisplayFor(m => node.Children, "MyMenuNodeList") @* <-- // Custom Node Helper Name *@
                }
            </li>
        }
    </ul>
    // MyMenuNodeList.cshtml
    @* // This template is for the descendent lists below the root level *@
    @model MvcSiteMapProvider.Web.Html.Models.SiteMapNodeModelList
    @using System.Web.Mvc.Html
    @using MvcSiteMapProvider.Web.Html.Models
    
    <ul>
        @foreach (var node in Model) { 
            <li>@Html.DisplayFor(m => node, "MyMenuNode") @* <-- // Custom Node Helper Name *@
                @if (node.Children.Any()) {
                    @Html.DisplayFor(m => node.Children, "MyMenuNodeList") @* <-- // Custom Node Helper Name *@
                }
            </li>
        }
    </ul>
    // MyMenuNode.cshtml
    @* // This template is for the node *@
    @model MvcSiteMapProvider.Web.Html.Models.SiteMapNodeModel
    @using System.Web.Mvc.Html
    @using MvcSiteMapProvider.Web.Html.Models
    
    Testing @* <-- // If configured right, Testing will appear before every node *@
    
    @if (Model.IsCurrentNode && Model.SourceMetadata["HtmlHelper"].ToString() != "MvcSiteMapProvider.Web.Html.MenuHelper")  { 
        <text>@Model.Title</text>
    } else if (Model.IsClickable) { 
        if (string.IsNullOrEmpty(Model.Description))
        {
            <a href="@Model.Url">@Model.Title</a>
        }
        else
        {
            <a href="@Model.Url" title="@Model.Description">@Model.Title</a>
        }
    } else { 
        <text>@Model.Title</text>
    }
