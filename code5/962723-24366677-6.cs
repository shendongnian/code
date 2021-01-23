    @using System.Web.Mvc.Html
    @using MyProject.Website.Helpers
    
    @{
        var type = Nullable.GetUnderlyingType(ViewData.ModelMetadata.ModelType) ?? ViewData.ModelMetadata.ModelType;
    
        @(typeof(Enum).IsAssignableFrom(type) ? Html.ExtEnumDropDownListFor(x => x) : Html.TextBoxFor(x => x))
    }
