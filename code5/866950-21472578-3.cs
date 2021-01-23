    @model MVC.Controllers.EnumViewModel
    
    @{
        ViewBag.Title = "Index";
    }
    
    <h2>Index</h2>
    
    @Html.ValidationSummary();
    
    @using (Html.BeginForm("Submit", "Enum", FormMethod.Post))
    {
        for (int i = 0; i < Model.CheckBoxItems.Count; i++)
        {
            @Html.LabelFor(m => m.CheckBoxItems[i].BloodGroup);
            @Html.CheckBoxFor(m => m.CheckBoxItems[i].IsSelected);
            @Html.HiddenFor(m => m.CheckBoxItems[i].BloodGroup);
        }
        
        <input type="submit" value="click"/>
    }
