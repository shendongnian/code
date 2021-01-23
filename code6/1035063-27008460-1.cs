    public class Service : IService {
         public void StartTasks() {
              BackgroundJob.Enqueue(() => this.MethodToQueue()); //Bad
         } 
          public void MethodToQueue() { ... }
    }
    public class AnyOtherClass {
         public AnyOtherClass(IService service) {
              service.StartTasks();
         }
    }
    
    
