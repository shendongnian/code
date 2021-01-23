    public class Activity {
      public int Id {get; private set;}
      public string Description {get;set;}
    
      public Activity (string description){
        this.Description = description 
        var activityRepository = kernel.Get<IActivityRepository>();
        this.Id = activityRepository .GetMaxId() + 1 
      }
    }
    
    public interface IActivityRepository{
      public int GetMaxId();
    }
