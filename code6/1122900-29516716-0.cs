    @model Project.Models.Person
    @{
        for (int i = 0; i < Model.Strings.Count; i++)
        {
            @Html.TextBox(string.Format("tb_{0}", i + 1), Model.Strings[i]);
        }
    }
