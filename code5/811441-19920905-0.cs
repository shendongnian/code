    @model System.DateTime?
    if (ViewData.ModelMetadata.IsNullableValueType)
    {
        <text></text>
    }
    else
    {
        @Model.Value.ToShortDateString()
    }
