    @helper RenderItems(string parentID, int indent = 0)
    {
        foreach (var contentPage in Model.ContentPages
                                         .Where(p => p.ParentReference == parentID)
                                         .OrderBy(p => p.SortOrder))
        {
            var index = Model.ContentPages.IndexOf(contentPage);
            <li style="padding-left: @(indent)px; color: red;">
                @Html.TextBoxFor(o => Model.ContentPages[index].Id)
                @contentPage.Title
                @Html.TextBoxFor(o => Model.ContentPages[index].SortOrder,
                    new { @class = "sortBox" })
            </li>
            @RenderItems(contentPage.Id, indent + 20)
        }
    }
