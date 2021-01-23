        /// <summary>
        ///     Provides an implemention of the <see cref="IGridContructor{TModel}" /> that is used to construct the grid through a
        ///     fluent API.
        /// </summary>
        /// <typeparam name="TModel">The type of the model that the grid will hold.</typeparam>
        public class GridConstructor<TModel> : IGridContructor<TModel>
        {
            #region Constructors
            /// <summary>
            ///     Creates a new instance of the <see cref="GridConstructor{TModel}" />.
            /// </summary>
            /// <param name="helper">The <see cref="HtmlHelper" /> that is used to built the model.</param>
            /// <param name="source">The model that is bound to the grid.</param>
            public GridConstructor(HtmlHelper helper, IEnumerable<TModel> source)
            {
                htmlHelper = helper;
                DataSource = source;
                builderProperties = new Dictionary<string, IColumnBinder<TModel>>();
            }
            #endregion
            #region Properties
            /// <summary>
            ///     Provides a dictionary that contains all the properties for the builder.
            /// </summary>
            public IDictionary<string, IColumnBinder<TModel>> builderProperties { get; set; }
            /// <summary>
            ///     Gets the source that will be bound to the implemented object.
            /// </summary>
            public IEnumerable<TModel> DataSource { get; private set; }
            /// <summary>
            ///     Gets the <see cref="HtmlHelper" /> object.
            /// </summary>
            public HtmlHelper htmlHelper { get; private set; }
            #endregion
        }
