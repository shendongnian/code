    @model WebApplication1.Models.NavigationViewModel
    <ul class="nav sf-menu clearfix">
        @foreach (var navigation in Model.Navigation)
        {
            int records = Model.Content.Count(c => c.NavigationId == navigation.Id);
            
            if (records > 0)
            {
                @Html.SubMenuLink(navigation.Title, navigation.Action, navigation.Controller)
                @Html.Raw("<ul>")
                foreach (var content in Model.Content.Where(c => c.NavigationId == navigation.Id))
                {
                    if (string.IsNullOrEmpty(content.Url))
                    {
                        if (string.IsNullOrEmpty(content.Content1))
                        {
                        }
                        else
                        {
                            @Html.MenuLink(content.Title, "Home/Article/" + content.Id + "/" + ToFriendlyUrl(content.Title), "Home");
                        }
                    }
                    else
                    {
                        @Html.MenuLink(content.Title, content.Url, "Home");
                    }
                }
                @Html.Raw("</ul>")
                @Html.Raw("</li>")
            }
            else
            {
                @Html.MenuLink(navigation.Title, navigation.Action, navigation.Controller)
            }
        }
    </ul>
