    @using MyProject.Website.Helpers
    
    @{
        var type = Nullable.GetUnderlyingType(ViewData.ModelMetadata.ModelType) ?? ViewData.ModelMetadata.ModelType;
    
        @(typeof(Enum).IsAssignableFrom(type) ? EnumViewsHelpers.GetResourceValueForEnumValue(Model) : Model)
    } 
