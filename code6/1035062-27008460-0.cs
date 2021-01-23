    public class Service : IService {
          public void MethodToQueue() { ... }
    }
    public class AnyOtherClass {
         public void StartTasks() {
              BackgroundJob.Enqueue<IService>(x => x.MethodToQueue()); //Good
         } 
    }
