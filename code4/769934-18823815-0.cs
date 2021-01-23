    public class Activity {
      public int Id {get; private set;}
      public string Description {get;set;}
    
      public Activity (string description){
        this.Description = description 
        this.Id = IActivityRepository.GetMaxId() + 1 // here need some dependency injection
      }
    }
    
    public interface IActivityRepository{
      public int GetMaxId();
    }
