    public static void Main
    {
         using (JobHost host = new JobHost())
         {
             host.Start();
     
             while (!TerminationCondition)
             {
                 if (SomeConditionRequiredForTheTrigger)
                 {
                     host.Call(typeof(Program).GetMethod("DoSomething"));
                 }
                 Thread.Sleep(500);
             }
             host.Stop();
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
