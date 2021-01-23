    public abstract class AbstractBlockRule
    {
        public long Id{get;set;}
        public abstract List<IRestriction> Restrictions { get; set; }
    }
    public interface IRestriction
    {
        object Limit { get; }
    }
    public interface IRestriction<T> : IRestriction 
        where T:struct
    {
        // hide IRestriction.Limit
        new T Limit {get;} 
    }
    public abstract class RestrictionBase<T> : IRestriction<T>
        where T:struct
    {
        // explicit implementation
        object IRestriction.Limit
        {
            get { return Limit; }
        }
        // override when required
        public virtual T Limit { get; set; }
    }
    public class TimeRestriction : RestrictionBase<TimeSpan>
    {
    }
    public class AgeRestriction : RestrictionBase<TimeSpan>
    {
    }
    public class BlockRule : AbstractBlockRule
    {
        public override List<IRestriction> Restrictions { get; set; }
    }
