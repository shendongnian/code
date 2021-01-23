    @model Project.Models.Person
    @{
        for (int i = 0; i < Model.Strings.Count; i++)
        {
            @Html.TextBox((string.Format("[{0}]", i), Model.Strings[i]);
        }
    }
