    @model MvcSiteMapProvider.Web.Html.Models.MenuHelperModel
    @using System.Web.Mvc.Html
    @using MvcSiteMapProvider.Web.Html.Models
    
    @helper  TopMenu(List<SiteMapNodeModel> nodeList)
    {
        <nav class="navbar navbar-default" role="navigation">
            <div class="container-fluid">
                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav">
                        @foreach (SiteMapNodeModel node in nodeList)
                        {
                            string url = node.IsClickable ? node.Url : "#";
    
                            if (!node.Children.Any())
                            {
                                <li class="@((node.IsCurrentNode || node.Descendants.Any(n => n.IsCurrentNode)) ? "active" : "")"><a href="@url">@node.Title</a></li>
                            }
                            else
                            {
                                <li class="dropdown @((node.IsCurrentNode || node.Descendants.Any(n => n.IsCurrentNode)) ? "active" : "")"><a class="dropdown-toggle" data-toggle="dropdown">@node.Title <span class="caret"></span></a>@DropDownMenu(node.Children)</li>
                            }
    
                            if (node != nodeList.Last())
                            {
                                <li class="divider-vertical"></li>
                            }
                        }
                    </ul>
                </div>
            </div>
        </nav>
    }
    
    @helper DropDownMenu(SiteMapNodeModelList nodeList)
    {
        <ul class="dropdown-menu" role="menu">
            @foreach (SiteMapNodeModel node in nodeList)
            {
                if (node.Title == "Separator")
                {
                    <li class="divider"></li>
                    continue;
                }
    
                string url = node.IsClickable ? node.Url : "#";
    
                if (!node.Children.Any())
                {
                    <li class="@((node.IsCurrentNode || node.Descendants.Any(n => n.IsCurrentNode)) ? "active" : "d")"><a href="@url">@node.Title</a></li>
                }
                else
                {
                    <li class="dropdown-submenu @((node.IsCurrentNode || node.Descendants.Any(n => n.IsCurrentNode)) ? "active" : "d")"><a href="@url">@node.Title</a>@DropDownMenu(node.Children)</li>
                }
            }
        </ul>
    }
    
    @TopMenu(Model.Nodes)
