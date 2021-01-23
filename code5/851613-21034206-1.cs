    @model MvcApplication1.Models.TestModel
    @using (Html.BeginForm())
    {
        for (var i = 0; i < Model.Items.Count; i++)
        {
            <p>
                @Html.TextBoxFor(x => Model.Items[i])
            </p>
            <p>@Html.ValidationMessageFor(x => Model.Items[i])</p>
        }
    
        <input type="submit" />
    }
