    public interface IRelation
    {
    }
    public class Relation<T1, T2> : IRelation
        where T1: Entity where T2: Entity
    {
    }
    public class RelationList : List<IRelation>
    {
    }
