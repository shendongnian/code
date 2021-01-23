    @model MvcSiteMapProvider.Web.Html.Models.SiteMapPathHelperModel
    @using System.Web.Mvc.Html
    @using System.Linq
    @using MvcSiteMapProvider.Web.Html.Models
    @foreach (var node in Model) { 
        @Html.DisplayFor(m => node); @* // <-- Need to add the diplaytemplate here, too *@
    
        if (node != Model.Last()) {
            <text> &gt; </text>
        }
    }
