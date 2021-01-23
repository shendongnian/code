    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
        /// <summary>
        /// Sets the display name for an Enum field
        /// </summary>
        /// <param name="displayName">The display name value to use</param>
        public EnumDisplayNameAttribute(string displayName)
            : base(displayName)
        {
        }
    }
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString EnumDropDownList<TEnumType>(this HtmlHelper htmlHelper, string name, TEnumType value)
        {
            var selectItems = GetSelectItemsForEnum(typeof(TEnumType), value);
            return htmlHelper.DropDownList(name, selectItems);
        }
        public static MvcHtmlString EnumDropDownListPlaceholder<TEnumType>(this HtmlHelper htmlHelper, string name, TEnumType value, string placeholderName = null)
        {
            var selectItems = GetSelectItemsForEnum(typeof(TEnumType), value);
            AddPlaceHolderToSelectItems(placeholderName, selectItems);
            return htmlHelper.DropDownList(name, selectItems, new { @class = "placeholder" });
        }
       
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes = null) where TModel : class
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            ModelState currentValueInModelState;
            var couldGetValueFromModelState = htmlHelper.ViewData.ModelState.TryGetValue(fullName, out currentValueInModelState);
            object selectedValue = null;
            if (!couldGetValueFromModelState &&
                htmlHelper.ViewData.Model != null)
            {
                selectedValue = expression.Compile()(htmlHelper.ViewData.Model);
            }
            var placeholderName = PlaceholderName(memberExpression);
            htmlAttributes = ApplyHtmlAttributes(htmlAttributes, placeholderName);
            var selectItems = GetSelectItemsForEnum(typeof(TProperty), selectedValue).ToList();
            AddPlaceHolderToSelectItems(placeholderName, selectItems);
            return htmlHelper.DropDownListFor(expression, selectItems, htmlAttributes);
        }
        public static MvcHtmlString PlaceholderDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes = null)
            where TModel : class
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");
            IList<SelectListItem> list = selectList.ToList();
            var placeholderName = PlaceholderName(memberExpression);
            AddPlaceHolderToSelectItems(placeholderName, list);
            htmlAttributes = ApplyHtmlAttributes(htmlAttributes, placeholderName);
            return htmlHelper.DropDownListFor(expression, list, string.IsNullOrEmpty(optionLabel) ? null : optionLabel, htmlAttributes);
        }
        public static IList<SelectListItem> GetSelectItemsForEnum(Type enumType, object selectedValue)
        {
            var selectItems = new List<SelectListItem>();
            if (enumType.IsGenericType &&
                enumType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                enumType = enumType.GetGenericArguments()[0];
                selectItems.Add(new SelectListItem { Value = string.Empty, Text = string.Empty });
            }
            var selectedValueName = selectedValue != null ? selectedValue.ToString() : null;
            var enumEntryNames = Enum.GetNames(enumType);
            var entries = enumEntryNames
                .Select(n => new
                {
                    Name = n,
                    EnumDisplayNameAttribute = enumType
                        .GetField(n)
                        .GetCustomAttributes(typeof(EnumDisplayNameAttribute), false)
                        .OfType<EnumDisplayNameAttribute>()
                        .SingleOrDefault() ?? new EnumDisplayNameAttribute("")
                })
                .Select(e => new
                {
                    Value = e.Name,
                    DisplayName = e.EnumDisplayNameAttribute.DisplayName ?? e.Name
                })
                .OrderBy(e => e.DisplayName)
                .Select(e => new SelectListItem
                {
                    Value = e.Value,
                    Text = e.DisplayName,
                    Selected = e.Value == selectedValueName
                });
            selectItems.AddRange(entries);
            return selectItems;
        }
        public static IEnumerable<string> GetNamesForEnum(Type enumType, object selectedValue)
        {
            if (enumType.IsGenericType &&
           enumType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                enumType = enumType.GetGenericArguments()[0];
            }
            var enumEntryNames = Enum.GetNames(enumType);
            var entries = enumEntryNames
                .Select(n => new
                {
                    Name = n,
                    EnumDisplayNameAttribute = enumType
                        .GetField(n)
                        .GetCustomAttributes(typeof(EnumDisplayNameAttribute), false)
                        .OfType<EnumDisplayNameAttribute>()
                        .SingleOrDefault() ?? new EnumDisplayNameAttribute("")
                })
                .Select(e => new
                {
                    Value = e.Name,
                    DisplayName = e.EnumDisplayNameAttribute.DisplayName ?? e.Name
                })
                .OrderBy(e => e.DisplayName)
                .Select(e => e.Value);
            return entries;
        }
        static string PlaceholderName(MemberExpression memberExpression)
        {
            var placeholderName = memberExpression.Member
                .GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)
                .Cast<EnumDisplayNameAttribute>()
                .Select(a => a.DisplayName)
                .FirstOrDefault();
            return placeholderName;
        }
        static void AddPlaceHolderToSelectItems(string placeholderName, IList<SelectListItem> selectList)
        {
            if (!selectList.Where(i => i.Text == string.Empty).Any())
                selectList.Insert(0, new SelectListItem { Selected = false, Text = placeholderName, Value = string.Empty });
            if (!selectList.Any() || selectList[0].Text != string.Empty) return;
            selectList[0].Value = "";
            selectList[0].Text = placeholderName;
        }
        static IDictionary<string, object> ApplyHtmlAttributes(IDictionary<string, object> htmlAttributes, string placeholderName)
        {
            if (!string.IsNullOrEmpty(placeholderName))
            {
                if (htmlAttributes == null)
                {
                    htmlAttributes = new Dictionary<string, object>();
                }
                if (!htmlAttributes.ContainsKey("class"))
                    htmlAttributes.Add("class", "placeholder");
                else
                {
                    htmlAttributes["class"] += " placeholder";
                }
            }
            return htmlAttributes;
        }
    }
