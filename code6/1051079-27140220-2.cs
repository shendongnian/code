    @model List<DynamicHyperLink>
    
    
    @{
        ViewBag.Title = "DynamicLinks";
    }
    
    <h2>DynamicLinks</h2>
    
    
    
    
    @if (Model != null && Model.Count > 0)
    {
        foreach (var item in Model)
        {
            <div>
                <a href="@item.Link">@item.Text</a>
            </div>
    
        }
    }
