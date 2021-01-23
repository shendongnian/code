    public bool MainMethod(int a, int b)
    {
      var employee = new Employee();
    
      ThreadPool.QueueUserWorkItem((argument) => { employee.DoWorkAsync(a, b); });
    
      return true;
    }
    
    public class Employee
    {
      public void DoWorkAsync(int a, int b)
      {
        // Do some work on a background thread.
      }
    }
