    public class QueueBuild : ITask
    {
        public IBuildEngine BuildEngine
        { get; set; }
        public ITaskHost HostObject
        { get; set; }
    
        [Required]
        public string tfsServer
        { get; set; }
    
        [Required]
        public string teamProject
        { get; set; }
    
        [Required]
        public string buildDefinition
        { get; set; }
    
        public bool Execute()
        {
            // set up support for logging
            TaskLoggingHelper loggingHelper = new TaskLoggingHelper(this);
    
            // Log Variables
            loggingHelper.LogMessageFromText("Custom Task QueueBuild Starting", MessageImportance.High);
            loggingHelper.LogMessageFromText("tfsServer = " + tfsServer , MessageImportance.High);
            loggingHelper.LogMessageFromText("teamProject = " + teamProject , MessageImportance.High);
            loggingHelper.LogMessageFromText("buildDefinition = " + buildDefinition , MessageImportance.High);
    
            // Get the team foundation server
            TeamFoundationServer tfs = TeamFoundationServerFactory.GetServer(tfsServer);
    
            // Get the IBuildServer 
            IBuildServer buildServer = (IBuildServer)tfs.GetService(typeof(IBuildServer));
    
            // Get the build definition for which a build is to be queued
            IBuildDefinition buildDef = buildServer.GetBuildDefinition(teamProject, buildDefinition);
    
            // Create variable for queuedBuild and queue the build 
            var queuedBuild = buildServer.QueueBuild(buildDef);
    
            loggingHelper.LogMessageFromText("Waiting for newly queued build from Team Project : " + teamProject + " : and Build Definition : " + buildDefinition + " : to complete", MessageImportance.High);
    
            loggingHelper.LogMessageFromText("Pinging queuedBuild : " + queuedBuild + " : every 5 seconds to confirm when build is complete", MessageImportance.High);
    
            // Wait for the completion of newly queued build - Will ping build every 5 seconds to confirm completion for a max of 5 hours
            queuedBuild.WaitForBuildCompletion(TimeSpan.FromSeconds(5), TimeSpan.FromHours(5));
    
            loggingHelper.LogMessageFromText("Queued Build : " + queuedBuild.Build.BuildNumber + " has now completed", MessageImportance.High);
    
            loggingHelper.LogMessageFromText("Returning to original build", MessageImportance.High);
    
            return true;
       
        }
    }
