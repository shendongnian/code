    public static class InputExtensions
    {
        public const string noteTemplate = @"<span class=""inputNote"">{0}</span>";
        public const string fieldClosing = @"</tr>";
        public const string fieldOpenning = @"<tr>";
        public const string fieldContent =
            @"<td class=""labelWrp""> {0} </td>     <td class=""inputWrp"" colspan=""{4}"">	{1} <br /> {2} {3} </td>";
        public static MvcHtmlString EnhancedEditorField<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
                    Expression<Func<TModel, TValue>> expression,
                    object htmlAttributes = null, string note = null)
        {
            return EnhancedField(htmlHelper, expression, htmlHelper.EditorFor(expression, htmlAttributes), note);
        }
        private static MvcHtmlString EnhancedField<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
                   Expression<Func<TModel, TValue>> expression, MvcHtmlString inputString,
                   string note = null, FieldGroupingSetting fieldGroupingSetting = FieldGroupingSetting.CloseBoth, bool checkIsRequired = true)
        {
            MvcHtmlString labelString = htmlHelper.EnhancedLabelFor(expression, checkIsRequired: checkIsRequired);
            MvcHtmlString validationMessageString = htmlHelper.ValidationMessageFor(expression);
            return CreateField(inputString.ToString(), note, labelString.ToString(), validationMessageString.ToString(),
                fieldGroupingSetting);
        }
        private static MvcHtmlString CreateField(string inputString, string note, string labelString,
                    string validationMessageString,
                    FieldGroupingSetting fieldGroupingSetting = FieldGroupingSetting.CloseBoth, int valueCellCount = 1)
        {
            string noteString = string.Empty;
            if (!string.IsNullOrWhiteSpace(note))
                noteString = string.Format(noteTemplate, note);
            string fieldTemplate =
                (fieldGroupingSetting.HasFlag(FieldGroupingSetting.CloseStart) ? fieldOpenning : string.Empty) +
                fieldContent +
                (fieldGroupingSetting.HasFlag(FieldGroupingSetting.CloseEnd) ? fieldClosing : string.Empty);
            string htmlString = string.Format(fieldTemplate, labelString, inputString, validationMessageString,
                noteString, valueCellCount);
            return MvcHtmlString.Create(htmlString);
        }
    }
