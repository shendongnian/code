        /// <summary>
        ///     Provides a way to extend the <see cref="HtmlHelper" /> to construct objects of various kinds.
        /// </summary>
        public static class HtmlHelperExtensions
        {
            #region Grid
            /// <summary>
            ///     Constructs a grid for a property that holds a collection.
            /// </summary>
            /// <typeparam name="TModel">The type of the model on which this grid is being build.</typeparam>
            /// <typeparam name="TEntity">The type of a single item in the collection.    </typeparam>
            /// <param name="htmlHelper">The helper on which this method is executed.    </param>
            /// <param name="dataSource">The datasource on which the items are bound.    </param>
            /// <returns>An <see cref="IGridBuilder{TEntity}" /> that is used to construct the grid.</returns>
            public static IGridBuilder<TEntity> GridFor<TModel, TEntity>(this     HtmlHelper<TModel> htmlHelper,
                IEnumerable<TEntity> dataSource)
            {
                return new GridBuilder<TEntity>(htmlHelper, dataSource);
            }
            #endregion
        }
