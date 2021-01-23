    @helper RecursiveMenuItem(INavigationItemContract menuItem)
    {
        if (menuItem.Pages != null && menuItem.Pages.Any())
        {
            if (menuItem.Pages.Count() == 1 || !menuItem.DisplayInMenu)
            {
                // Only one page, so this will be the default.
                // Other option is that the pages should not be displayed, so then we'll only display the link to the site.
                <li><a href="@menuItem.Url">@menuItem.Title</a></li>
            }
            else
            {
                <li>
                    <a href="#">@menuItem.Title aa</a>
                    <ul class="dropdown-menu">
                        @foreach (var page in menuItem.Pages)
                        {
                            <li><a href="@page.Url">@page.Title</a></li>
                        }
                        @foreach (var site in menuItem.Sites)
                        {
                            @RecursiveMenuItem(site)
                        }
                    </ul>
                </li>
            }
        }
    }
    <div role="navigation">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li><a href="">Home</a></li>
                @foreach (var menuItem in Model)
                {
                    @RecursiveMenuItem(menuItem)
                }
            </ul>
        </div>
    </div>
