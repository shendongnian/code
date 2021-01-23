    @model MVCModelDemo.Models.ParentModel //Note the model passed to the view here
    @{
    
        ViewBag.Title = "Home Page";
    }
    
    @using (Html.BeginForm("SearchMethod", "Home", new { area = "" }))
    {
        @Html.TextBoxFor(modelItem => modelItem.Name)
        @Html.TextBoxFor(modelItem => modelItem.ChildModel.Name)
        <button type="submit">Search</button>
    }
