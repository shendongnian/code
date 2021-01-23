    @model System.Collections.Generic.IList<decimal?>
    
    @{
        ViewBag.Title = "Collection";
        var modelMetadata = this.ViewData.ModelMetadata;
        var validators = modelMetadata.GetValidators(ViewContext).ToList();
        ViewContext.HttpContext.Items["rootValidators"] = validators;
    }
    
    @for (var i = 0; i < Model.Count(); i++)
    {
        @Html.EditorFor(model => Model[i], new { htmlAttributes = new { @class = "form-control" } })
        @Html.ValidationMessageFor(model => Model[i], "", new { @class = "text-danger" })
    }
