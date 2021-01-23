    var container = new Container();
    // TODO: Your registrations here.
    // Hook the profiler
    List<ProfileData> profileLog = new List<ProfileData>(1000);
    // Call this after all registrations.
    EnableProfiling(container, profileLog);
    // Trigger verification to allow everything to be precompiled.
    container.Verify();
    
    profileLog.Clear();
            
    // Resolve a type:
    container.GetInstance<AuditFacade>();
    // Display resolve time in order of time.
    var slowestFirst = profileLog.OrderByDescending(line => line.Elapsed);
    foreach (var line in slowestFirst)
    {
        Console.WriteLine(string.Format("{0} ms: {1}", 
            line.Info.KnownImplementationType.Name, 
            line.Elapsed.TotalMilliseconds);
    }
