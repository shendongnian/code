    @model List<Namespace.To.MyModel>
    @using (Html.BeginForm())
    {
        for (var i = 0; i < Model.Count(); i++)
        {
            // Model fields here, i.e.
            // @Html.EditorFor(m => m[i].SomeField)
        }
        <button type="submit">Submit</button>
    }
