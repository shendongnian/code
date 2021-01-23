    @model ViewModelProspects
    @using (Html.BeginForm())
    {
        for (var i = 0; i < Model.Prospects.Count(); i++)
        {
            <label>
                @Html.HiddenFor(m => Model.Prospects[i].Id)
                @Html.CheckboxFor(m => Model.Prospects[i].Selected, true)
                @Model.Prospects[i].Name
            </label>
        }
    }
