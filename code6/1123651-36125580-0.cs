    @model MyViewModel
    @using (Html.BeginForm())
    {
        for(int i = 0; i < Model.GridModels.Count; i++)
        {
            @Html.TextBoxFor(m => m.GridModels[i].GridField)
        }
    }
