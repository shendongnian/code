    public void Bind<TItem>(Expression<Func<TModel, TItem>> propertySelector)
    {
      string name = ExpressionHelper.GetExpressionText(propertySelector);
      name = HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
      IEnumerable collection = HtmlHelper.ViewData.Model as IEnumerable;
      foreach (var item in collection)
      {
        ModelMetadata modelMetadata = ModelMetadataProviders.Current
          .GetMetadataForType(() => item, item.GetType())
          .Properties.First(m => m.PropertyName == name);
        string displayName = modelMetadata.GetDisplayName();
        if (!properties.ContainsKey(displayName))
        {
          properties[displayName] = new List<string>();
        }
        // Take into account display format and null values
        string format = modelMetadata.DisplayFormatString ?? "{0}";
        properties[displayName].Add(string.Format(format, 
          modelMetadata.Model ??  modelMetadata.NullDisplayText));     
      }
    }
