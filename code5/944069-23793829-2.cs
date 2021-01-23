    @helper RenderItems(string parentID, int indent = 0)
    {
        int index = ViewBag.ItemIndex ?? 0;
        foreach (var contentPage in Model.ContentPages
                                         .Where(p => p.ParentReference == parentID)
                                         .OrderBy(p => p.SortOrder))
        {
            
            <li style="padding-left: @(indent)px; color: red;">
                @contentPage.Title 
                @Html.TextBoxFor(o => Model.ContentPages[index].SortOrder, 
                                         new { @class = "sortBox" })
            </li>
            ViewBag.ItemIndex = ++index;
            @RenderItems(contentPage.Id, indent+20);
            index = ViewBag.ItemIndex;
        }
    }
