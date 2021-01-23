    PostValidator validator = new PostValidator();
    foreach (var rule in validator.AsEnumerable())
    {
        propertyRule = rule as FluentValidation.Internal.PropertyRule;
        if (propertyRule == null)
            continue;
        WebControl control = (WebControl)FindControl("Post" + propertyRule.PropertyName);
        foreach (var x in rule.Validators)
        {
            if (x is FluentValidation.Validators.NotEmptyValidator)
            {
                control.Attributes["required"] = "required";
            }
            else if (x is FluentValidation.Validators.MaximumLengthValidator)
            {
                var a = (FluentValidation.Validators.MaximumLengthValidator)x;
                control.Attributes["size"] = a.Max.ToString();
                control.Attributes["minlength"] = a.Min.ToString();
                control.Attributes["maxlength"] = a.Max.ToString();
            }
            ...
        }
    }
