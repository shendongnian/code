    public class WorkItemFieldCollection : IEnumerable<Field>, IQueryable<Field>
    {
        ...
        #region Implementation of IQueryable<Field>
        public Type ElementType
        {
            get
            {
                return this._fieldList.AsQueryable().ElementType;
            }
        }
        public Expression Expression
        {
            get
            {
                return this._fieldList.AsQueryable().Expression;
            }
        }
        public IQueryProvider Provider
        {
            get
            {
                return this._fieldList.AsQueryable().Provider;
            }
        }
        #endregion
        ...
    }
