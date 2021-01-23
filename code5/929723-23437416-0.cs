    @model System.Collections.Generic.IEnumerable<object>
    @{
        ViewBag.Title = "Collection";
        var modelMetadata = this.ViewData.ModelMetadata;
        var validators = modelMetadata.GetValidators(ViewContext).ToList();
        ViewContext.HttpContext.Items["rootValidators"] = validators;
    }
    @foreach (var item in Model)
    {
        @Html.EditorFor(m => item)
    }
