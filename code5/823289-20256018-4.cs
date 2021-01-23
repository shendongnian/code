    @model Person
    @foreach (var prop in ViewData.ModelMetadata.Properties)
    {
        if (prop.HasDisplayIfAttribute())
        { 
            <p>@Html.DisplayIfFor(x => prop)</p>
        }
        else
        { 
            <p>@Html.DisplayFor(x => prop.Model)</p>
        }
    }
