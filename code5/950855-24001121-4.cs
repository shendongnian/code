        /// <summary>
        ///     Provides an implemention of the <see cref="IGridBuilder{TModel}" /> that is used to construct the grid through a
        ///     fluent API.
        /// </summary>
        /// <typeparam name="TModel">The type of the model that the grid will hold.</typeparam>
        public class GridBuilder<TModel> : IGridBuilder<TModel>
        {
            #region Constructors
            /// <summary>
            ///     Creates a new instance of the <see cref="GridBuilder{TModel}" />.
            /// </summary>
            /// <param name="helper">The <see cref="HtmlHelper" /> that is used to construct the grid.</param>
            /// <param name="dataSource">The collection of objects that will be bound to the grid.</param>
            public GridBuilder(HtmlHelper helper, IEnumerable<TModel> dataSource)
            {
                htmlHelper = helper;
                DataSource = dataSource;
                Constructor = new GridConstructor<TModel>(htmlHelper, DataSource);
            }
            #endregion
            #region IGridBuilder Members
            /// <summary>
            ///     Gets the name of the <see cref="IGridBuilder{TModel}" />.
            /// </summary>
            public string Name { get; private set; }
            /// <summary>
            ///     Gets the constructor that will be used to construct this <see cref="IGridBuilder{TModel}" />.
            /// </summary>
            public IGridContructor<TModel> Constructor { get; set; }
            /// <summary>
            ///     Gets the source that will be bound to the implemented object.
            /// </summary>
            public IEnumerable<TModel> DataSource { get; private set; }
            /// <summary>
            ///     Gets the <see cref="HtmlHelper" /> object.
            /// </summary>
            public HtmlHelper htmlHelper { get; private set; }
            /// <summary>
            ///     Sets the name of the <see cref="IGridBuilder{TModel}" />. This name will be used as an id on the outer element that
            ///     holds the entire grid.
            /// </summary>
            /// <param name="name">The name that the <see cref="IGridBuilder{TModel}" /> should have.</param>
            /// <returns>An <see cref="IGridBuilder{TModel}" /> that can be used to construct the grid through a fluent API.</returns>
            public IGridBuilder<TModel> WithName(string name)
            {
                Name = name;
                return this;
            }
            /// <summary>
            ///     Set the columns of the model that should be bound to grid.
            /// </summary>
            /// <param name="bindAllColumns">The action that will bind all the columns.</param>
            /// <returns>An <see cref="IGridBuilder{TModel}" /> that is used to construct the grid.</returns>
            public IGridBuilder<TModel> WithColumns(Action<IColumnBinder<TModel>> bindAllColumns)
            {
                var columnBinder = new ColumnBinder<TModel>(Constructor);
                bindAllColumns(columnBinder);
                return this;
            }
            /// <summary>
            ///     Renders the grid with all the set properties.
            /// </summary>
            /// <returns>A <see cref="MvcHtmlString" /> that contains the HTML representation of the grid.</returns>
            public MvcHtmlString Render()
            {
                var outputBuilder = new StringBuilder();
                BaseElementBuilder parentElement = DivFactory.DivElement().WithCss("header");
                outputBuilder.Append(parentElement.ToString(TagRenderMode.StartTag));
                outputBuilder.Append(parentElement.ToString(TagRenderMode.EndTag));
                return new MvcHtmlString(outputBuilder.ToString());
            }
            #endregion
        }
