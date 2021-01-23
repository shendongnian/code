    @using MvcApplication1.Utility
    @if (ViewData.TemplateInfo.TemplateDepth > 1) {
        @ViewData.ModelMetadata.SimpleDisplayText
    } else {
        foreach (var prop in ViewData.ModelMetadata.Properties.Where(pm => pm.ShowForDisplay && !ViewData.TemplateInfo.Visited(pm))) {
            var htmlString = prop.IsReadOnly ? Html.Display(prop.PropertyName) : Html.Editor(prop.PropertyName);
            if (prop.HideSurroundingHtml) {
                @htmlString
            }
            else
            {
                var errors = Html.ValidationErrors(prop);
                <div class="form-group @(prop.IsReadOnly ? "form-group-readonly" : "") @(errors.Any() ? "has-error has-feedback" : "")">
                    <label class="control-label" for="@ViewData.TemplateInfo.GetFullHtmlFieldId(prop.PropertyName)">@prop.GetDisplayName()</label>
                    @htmlString
                    @foreach (var err in errors)
                    {
                        <div class="field-validation-error">@err.ErrorMessage</div>
                    }
                </div>
            }
        }
    }
