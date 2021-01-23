    @model Enum
    
    @{    
        var listItems = Enum.GetValues(Model.GetType()).OfType<Enum>().Select(e =>
            new SelectListItem
            {
                Text = e.DisplayName(),
                Value = e.ToString(),
                Selected = e.Equals(Model)
            });
        var prefix = ViewData.TemplateInfo.HtmlFieldPrefix;
        var index = 0;
        ViewData.TemplateInfo.HtmlFieldPrefix = string.Empty;
    
        foreach (var li in listItems)
        {
            var fieldName = string.Format(CultureInfo.InvariantCulture, "{0}_{1}", prefix, index++);
            <div class="editor-radio">
                @Html.RadioButton(prefix, li.Value, li.Selected, new {@id = fieldName})
                @Html.Label(fieldName, li.Text)
            </div>
        }
        ViewData.TemplateInfo.HtmlFieldPrefix = prefix;
    }
