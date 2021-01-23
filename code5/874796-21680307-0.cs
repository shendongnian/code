    @model Enum
     
    @{
         // Looks for a [Display(Name="Some Name")] or a [Display(Name="Some Name", ResourceType=typeof(ResourceFile)] Attribute on your enum
        Func<Enum, string> getDescription = en =>
        {
            Type type = en.GetType();
            System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());
     
            if (memInfo != null && memInfo.Length > 0)
            {
     
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute),
                                                                false);
     
                if (attrs != null && attrs.Length > 0)
                    return ((System.ComponentModel.DataAnnotations.DisplayAttribute)attrs[0]).GetName();
            }
     
            return en.ToString();
        };
        var listItems = Enum.GetValues(Model.GetType()).OfType<Enum>().Select(e =>
        new SelectListItem()
        {
            Text = getDescription(e),
            Value = e.ToString(),
            Selected = e.Equals(Model)
        });
        string prefix = ViewData.TemplateInfo.HtmlFieldPrefix;
        int index = 0;
        ViewData.TemplateInfo.HtmlFieldPrefix = string.Empty;
        
        foreach (var li in listItems)
        {
            string fieldName = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}_{1}", prefix, index++);
            <div class="editor-radio">
            @Html.RadioButton(prefix, li.Value, li.Selected, new { @id = fieldName }) 
            @Html.Label(fieldName, li.Text)    
            </div>
        }
        ViewData.TemplateInfo.HtmlFieldPrefix = prefix;
    }
