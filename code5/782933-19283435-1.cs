    @model int?
    
    @if (ViewBag.ReadOnly != null && ViewBag.ReadOnly)
    {
        var item = SelectLists.CompanyClasses(Model).FirstOrDefault(x => x.Selected);
        
        if (item != null)
        {
            <span>@item.Text</span>
        }
    }
    else
    {
        @Html.DropDownListFor(x => x, SelectLists.CompanyClasses(Model))    
    }
