        /// <summary>
        ///     Returns a completely formatted form element for the given expression, including label, input and validation messages
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="html"></param>
        /// <param name="propertyExpression"></param>
        /// <param name="editorHtml"></param>
        /// <param name="labelHtml"></param>
        /// <param name="validationHtml"></param>
        /// <returns></returns>
        public static MvcHtmlString FormElementFor<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> propertyExpression,
            IHtmlString editorHtml,
            IHtmlString labelHtml,
            IHtmlString validationHtml)
        {
            return MvcHtmlString.Create(labelHtml.ToHtmlString() + editorHtml.ToHtmlString() +validationHtml.ToHtmlString());
        }
        /// <summary>
        ///     Method to build form input with label, editor and validation message.
        /// </summary>
        /// <example>
        ///     <code>
        ///         Html.FormElementFor(model => model.MyProperty)
        ///     </code>
        /// </example>
        /// <typeparam name="TModel">Model</typeparam>
        /// <typeparam name="TProperty">Property of the model</typeparam>
        /// <param name="html">This Html Helper</param>
        /// <param name="propertyExpression">Expression to get property of the model</param>
        /// <returns></returns>
        public static MvcHtmlString FormElementFor <TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> propertyExpression)
        {
            return html.FormElementFor(propertyExpression,
                                       html.EditorFor(propertyExpression),
                                       html.LabelFor(propertyExpression, new  { @class = "control-label" }),
                                       html.ValidationMessageFor(propertyExpression));
        }
        /// <summary>
        ///     Method to build form input with label, editor and validation message.
        /// </summary>
        /// <example>
        ///     <code>
        ///         Html.FormElementFor(model => model.MyProperty, Html.DropDownListFor(model => model.MyProperty, MySelectList))
        ///     </code>
        /// </example>
        /// <typeparam name="TModel">Model</typeparam>
        /// <typeparam name="TProperty">Property of the model</typeparam>
        /// <param name="html">This Html Helper</param>
        /// <param name="propertyExpression">Expression to get property of the model</param>
        /// <param name="editorHtml">Some custom MvcHtmlString to use as the editor field</param>
        /// <returns></returns>
        public static MvcHtmlString FormElementFor <TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> propertyExpression,
            IHtmlString editorHtml)
        {
            return html.FormElementFor(propertyExpression,
                                       editorHtml,
                                       html.LabelFor(propertyExpression, new { @class = "control-label" }),
                                       html.ValidationMessageFor(propertyExpression));
        }
        /// <summary>
        ///     Method to build form input with label, editor and validation message.
        /// </summary>
        /// <example>
        ///     <code>
        ///         Html.FormElementFor(model => model.MyProperty, Html.CheckBoxFor(model => model.MyBoolean), Html.DisplayNameFor(model => model.SomeOtherProperty))
        ///     </code>
        /// </example>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="html"></param>
        /// <param name="propertyExpression"></param>
        /// <param name="editorHtml"></param>
        /// <param name="labelHtml"></param>
        /// <returns></returns>
        public static MvcHtmlString FormElementFor <TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> propertyExpression,
            IHtmlString editorHtml,
            IHtmlString labelHtml
            )
        {
            return html.FormElementFor(propertyExpression,
                                       editorHtml,
                                       labelHtml,
                                       html.ValidationMessageFor(propertyExpression));
        }
        /*** EXTRAS ***/
        /// <summary>
        ///     Method to build form input with label, editor and validation message.
        /// </summary>
        /// <example>
        ///     <code>
        ///         Html.FormElementFor(model => model.MyProperty, Html.TextAreaFor)
        ///     </code>
        /// </example>
        /// <typeparam name="TModel">Model</typeparam>
        /// <typeparam name="TProperty">Property of the model</typeparam>
        /// <param name="html">This Html Helper</param>
        /// <param name="expression">Expression to get property of the model</param>
        /// <param name="editor">Editor expression that takes the previous expression parameter and converts it into a MvcHtmlString</param>
        /// <returns></returns>
        public static MvcHtmlString FormElementFor <TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            Func<Expression<Func<TModel, TProperty>>, MvcHtmlString> editor)
        {
            return FormElementFor(html, expression, editor(expression));
        }
        /// <summary>
        ///     Method to build form input with label, editor and validation message.
        /// </summary>
        /// <example>
        ///     <code>
        ///         Html.FormElementFor(model => model.MyProperty, Html.TextAreaFor, Html.MyDisplayHelper(model => model.MyProperty))
        ///     </code>
        /// </example>
        /// <typeparam name="TModel">Model</typeparam>
        /// <typeparam name="TProperty">Property of the model</typeparam>
        /// <param name="html">This Html Helper</param>
        /// <param name="expression">Expression to get property of the model</param>
        /// <param name="editor">Editor expression that takes the previous expression parameter and converts it into a MvcHtmlString</param>
        /// <param name="labelHtml">Html to use as the label</param>
        /// <returns></returns>
        public static MvcHtmlString FormElementFor <TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            Func<Expression<Func<TModel, TProperty>>, MvcHtmlString> editor,
            IHtmlString labelHtml)
        {
            return FormElementFor(html, expression, editor(expression), labelHtml);
        }
        /// <summary>
        ///     Method to build form input with label, editor and validation message.
        /// </summary>
        /// <example>
        ///     <code>
        ///         Html.FormElementFor(model => model.MyProperty, Html.TextAreaFor, Html.DisplayFor)
        ///     </code>
        /// </example>
        /// <typeparam name="TModel">Model</typeparam>
        /// <typeparam name="TProperty">Property of the model</typeparam>
        /// <param name="html">This Html Helper</param>
        /// <param name="expression">Expression to get property of the model</param>
        /// <param name="editor">Editor expression that takes the previous expression parameter and converts it into a IHtmlString</param>
        /// <param name="label">Label expression that takes the previous expression parameter and converts it into a IHtmlString</param>
        /// <returns></returns>
        public static MvcHtmlString FormElementFor <TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            Func<Expression<Func<TModel, TProperty>>, MvcHtmlString> editor,
            Func<Expression<Func<TModel, TProperty>>, MvcHtmlString> label)
        {
            return FormElementFor(html, expression, editor(expression), label(expression));
        }
