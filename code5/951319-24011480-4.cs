    public class ColumnBuilderFactory<TModel> : IColumnBuilderFactory<TModel>
    {
        #region Constructors
    
        public ColumnBuilderFactory(IGridBuilder<TModel> gridBuilder)
        {
            gridBuilderReference = gridBuilder;
        }
    
        #endregion
    
        #region IColumnBuilderFactory Members
    
        private IGridBuilder<TModel> gridBuilderReference { get; private set; }
    
        internal IList<IColumnBuilder<TModel>> Columns {get; private set; }
    
        public IColumnBuilder<TModel> New()
        {
            var column = new ColumnBuilder(gridBuilderReference);
            Columns.Add(column);
            return column;
        }
    
        #endregion
    }
