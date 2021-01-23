        public interface IDataSource<out TModel>
        {
            #region Properties
             /// <summary>
             ///     Gets the source that will be bound to the implemented object.
             /// </summary>
             IEnumerable<TModel> DataSource { get; }
             #endregion
        }
