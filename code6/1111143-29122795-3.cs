    public ActionResult TranslatedView(string viewName, object model)
    {
        foreach (var property in type.GetProperties())
        {
            /* Using the Castle.Core HasAttribute method - go with whatever
             * you like. */
            if (property.HasAttribute<TranslatableAttribute>())
            {
                var value = property.GetValue(model) as string;
                if (value != null)
                {
                    property.SetValue(model, _myClass.Translate(value));
                }
            }
        }
    
        return View(viewName, model);
    }
