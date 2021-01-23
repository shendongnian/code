    @model List<TestWebApplication.Models.ModelB>
    ...
    @using (Html.BeginForm())
    {
        for (int i = 0; i < Model.Count; i++)
        {
            Age: @Html.EditorFor(modelItem => Model[i].Age);
            Name: @Html.EditorFor(modelItem => Model[i].Name);
            <br />
        }
       
        <input type="submit"/>
    }
