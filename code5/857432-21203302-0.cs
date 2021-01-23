    public abstract class AbstractBlockRule
    {
        public long Id{get;set;}
        public abstract List<IRestriction> Restrictions {get;};
    }
    
    public interface IRestriction{}
    
    public interface IRestrictionWithLimit<T>:IRestriction where T:struct
    {
        T Limit {get;} 
    }
    
    public TimeRestriction:IRestrictionWithLimit<TimeSpan>
    {
        public TimeSpan Limit{get;set;}
    }
    
    public AgeRestriction:IRestrictionWithLimit<int>
    {
        public int Limit{get;set;}
    }
    
    public class BlockRule:AbstractBlockRule
    {
        public virtual List<IRestriction> Restrictions {get;set;}
    }
