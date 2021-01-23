        @model MVC.Controllers.CheckboxlistViewModel
        
        @{
            ViewBag.Title = "Index";
        }
        
        <h2>Index</h2>
        
        <div>
        @using (Html.BeginForm("Submit", "Checkboxlist",FormMethod.Post))
        {
            for (int i = 0; i < Model.categories.Count; i++)
            {
                @Html.HiddenFor(m => m.categories[i].Category)
                @Html.CheckBoxFor(m => m.categories[i].IsSelected) @Html.Label(Model.categories[i].Category)
            }
            <input type="submit" value="Submit"/>
        }
        </div>
