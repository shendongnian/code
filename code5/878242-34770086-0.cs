    public interface ITrackerSection {
       SectionType Section { get; }
    }
    
    public enum SectionType{
       0 = Scope,
       1 = Sample
    }
