    public interface IRelationBaseList
    {
        IEnumerable<RelationBase> Collection { get; }
    }
    public class RelationBaseList<T> : IRelationBaseList where T : RelationBase
    {
        IEnumerable<RelationBase> IRelationBaseList.Collection
        {
            get { return Collection; }
        }
        public List<T> Collection { get; set; }
    }
    public class RelationURLList : RelationBaseList<RelationURL>
    {
    }
