    public class MyClass
    {
       private readonly Task _task;
       public MyClass(Task task) 
       { 
         if (task == null)
         {
           throw new ArgumentNullException("task");
         }
         this._task = task; 
       }
    
       public async Task Execute()
       {
          await this._task;
       }
    }
