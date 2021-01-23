        /// <summary>
        ///     Provides an implementation of the <see cref="IColumnBinder{TModel}" /> that can be used to construct a column
        ///     through a fluent API.
        /// </summary>
        /// <typeparam name="TModel">The type of the datasource that's bound to the grid.</typeparam>
        public class ColumnBinder<TModel> : IColumnBinder<TModel>
        {
            #region Constructors
            /// <summary>
            ///     Creates a new instance of the <see cref="ColumnBinder{TModel}" />.
            /// </summary>
            /// <param name="constructor">An <see cref="IGridContructor{TModel}" /> that contains the builder to construct the grid.</param>
            public ColumnBinder(IGridContructor<TModel> constructor)
            {
                Constructor = constructor;
            }
            #endregion
            #region IColumnBinder Members
            /// <summary>
            ///     Gets the values that are bound to this <see cref="IColumnBinder{TModel}" />.
            /// </summary>
            public IGridContructor<TModel> Constructor { get; private set; }
            /// <summary>
            ///     Gets the css class of the <see cref="IColumnBinder{TModel}" />.
            /// </summary>
            public string CssClass { get; private set; }
            /// <summary>
            ///     Gets the values that are bound to this <see cref="IColumnBinder{TModel}" />.
            /// </summary>
            public IList<object> Values { get; set; }
            /// <summary>
            ///     Binds an column to the grid.
            /// </summary>
            /// <typeparam name="TItem">The type of the column on which to bind the items.</typeparam>
            /// <param name="propertySelector">The functional that will bind the control to the grid.</param>
            /// <returns>As <see cref="IColumnBinder{TModel}" /> that is used to construct this column through a fluent API.</returns>
            public IColumnBinder<TModel> Bind<TItem>(Expression<Func<TModel, TItem>> propertySelector)
            {
                string name = ExpressionHelper.GetExpressionText(propertySelector);
                name = Constructor.htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
                ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForProperty(() => default(TModel),
                    typeof (TModel), name);
                // Get's the name to display on the column in grid. The Display attribute is used if present, otherwise the name of the property is used.
                string displayName = string.IsNullOrEmpty(metadata.DisplayName)
                    ? metadata.PropertyName
                    : metadata.DisplayName;
                Values =
                    Constructor.DataSource.Select(myVar => propertySelector.Compile()(myVar))
                        .Select(dummy => (object) dummy)
                        .ToList();
                Constructor.builderProperties.Add(displayName, this);
                return this;
            }
            /// <summary>
            ///     Apply a specific css class on an element.
            /// </summary>
            /// <param name="className">The name of the css class that should be placed on the element.</param>
            /// <returns>As <see cref="IColumnBinder{TModel}" /> that is used to construct this column through a fluent API.</returns>
            public IColumnBinder<TModel> WithCss(string className)
            {
                CssClass = className;
                return this;
            }
            #endregion
        }
