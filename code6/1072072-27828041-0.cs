    @{
        var htmlAttributes = new Dictionary<string, string>();
        foreach(var validator in ViewData.ModelMetadata.GetValidators(ViewContext).SelectMany(v => v.GetClientValidationRules())) {
            var parameters = validator.ValidationParameters;
                
            if(validator is ModelClientValidationRegexRule) {
                htmlAttributes.Add("ng-pattern", parameters["pattern"]);
            } else if(validator is ModelClientValidationRangeRule) {
                htmlAttributes.Add("ng-minlength", parameters["min"]);
                htmlAttributes.Add("ng-maxlength", parameters["max"]);
            } else if(validator is ModelClientValidationStringLengthRule) {
                htmlAttributes.Add("ng-minlength", parameters["minlength"]);
                htmlAttributes.Add("ng-maxlength", parameters["maxlength"]);
            }
        }
    }
    @Html.TextBox("", ViewData.TemplateInfo.FormattedModelValue, htmlAttributes)
