    public interface IPlanRepository
    {
        IEnumerable<IPlan> GetPlans(IPlan plan);
        IEnumerable<IPlan> GetAllPlans();
        IEnumerable<string> DoSomethingElse();
    }
    
    public class PlanRepository : IPlanRepository
    {
        IEnumerable<IPlan> GetPlans(IPlan plan)
        {
            // fill a List with Plans
        }
        IEnumerable<IPlan> planList = GetAllPlans();
        {
            // fill a List with Plans
        }
        //
        // Do stuff with planList...
        //
    }
    
    public interface IPlan
    {
       // properties and methods relating to a Plan (NOT how to "get" a Plan)
    }
    
    public class Plan : IPlan
    {
        // implementation of properties and methods
    }
