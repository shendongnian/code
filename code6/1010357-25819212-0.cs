    public static void Main
    {
         using(JobHost host = new JobHost())
         {
             // Invoke the function from code
             host.Call(typeof(Program).GetMethod("DoSomething"));
             // The RunAndBlock here is optional. However,
             // if you want to be able to invoke the function below
             // from the dashboard, you need the host to be running
             host.RunAndBlock();
             // Alternative to RunAndBlock is Host.Start and you
             // have to create your own infinite loop that keeps the
             // process alive
        }
    }
    // In order for a function to be indexed and visible in the dashboard it has to 
    // - be in a public class
    // - be public and static
    // - have at least one WebJobs SDK attribute
    [NoAutomaticTrigger]
    public static void DoSomething(TextWriter log)
    {
        log.WriteLine("Doing something. Maybe some SQL stuff?");
    }
