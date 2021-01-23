    @helper  RenderItems(string parentID, int index = 0)
    {
        foreach (var contentPage in Model.ContentPages.Where(p=>p.ParentReference == parentID)
                                                      .OrderBy(p=>p.SortOrder))
        {
            <li>@contentPage.Title @Html.TextBoxFor(o => Model.ContentPages[index].SortOrder, new {@class = "sortBox"})</li>
            @RenderItems(contentPage.Id, index++);
        }
    }
