    /// <summary>
    /// Returns an HTML select element for each value in the enumeration that is
    /// represented by the specified expression and predicate.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TEnum">The type of the value.</typeparam>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
    /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
    /// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
    /// <param name="predicate">A <see cref="Func{TEnum, bool}"/> to filter the items in the enums.</param>
    /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
    /// <returns>An HTML select element for each value in the enumeration that is represented by the expression and the predicate.</returns>
    /// <exception cref="ArgumentNullException">If expression is null.</exception>
    /// <exception cref="ArgumentException">If TEnum is not Enum Type.</exception>
    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, Func<TEnum, bool> predicate, string optionLabel, object htmlAttributes) where TEnum : struct, IConvertible
    {
        if (expression == null)
        {
            throw new ArgumentNullException("expression");
        }
        if (!typeof(TEnum).IsEnum)
        {
            throw new ArgumentException("TEnum");
        }
        
        ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        IList<SelectListItem> selectList = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Where(e => predicate(e))
                .Select(e => new SelectListItem
                    {
                        Value = Convert.ToUInt64(e).ToString(),
                        Text = ((Enum)(object)e).GetDisplayName(),
                    }).ToList();
        if (!string.IsNullOrEmpty(optionLabel)) {
            selectList.Insert(0, new SelectListItem {
                Text = optionLabel,
            });
        }
        return htmlHelper.DropDownListFor(expression, selectList, htmlAttributes);
    }
    /// <summary>
    /// Gets the name in <see cref="DisplayAttribute"/> of the Enum.
    /// </summary>
    /// <param name="enumeration">A <see cref="Enum"/> that the method is extended to.</param>
    /// <returns>A name string in the <see cref="DisplayAttribute"/> of the Enum.</returns>
    public static string GetDisplayName(this Enum enumeration)
    {
        Type enumType = enumeration.GetType();
        string enumName = Enum.GetName(enumType, enumeration);
        string displayName = enumName;
        try
        {
            MemberInfo member = enumType.GetMember(enumName)[0];
            object[] attributes = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            DisplayAttribute attribute = (DisplayAttribute)attributes[0];
            displayName = attribute.Name;
            if (attribute.ResourceType != null)
        {
                displayName = attribute.GetName();
            }
        }
        catch { }
        return displayName;
    }
