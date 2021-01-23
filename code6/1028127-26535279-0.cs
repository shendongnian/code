    public class RetainedApplicationsHub : Hub
    {
        private static readonly ConcurrentDictionary<Guid, RetainedApplication> RetainedApplications = new ConcurrentDictionary<Guid, RetainedApplication>();
        public static bool IsApplicationRetained(Guid applicationId)
        {
            return RetainedApplications.ContainsKey(applicationId);
        }
        public void RetainApplication(Guid applicationId, Guid personId)
        {
            var retainedSuccessfully = RetainedApplications.TryAdd(applicationId, new RetainedApplication{ConnectionId = Context.ConnectionId, PersonId = personId});
            if(retainedSuccessfully)
                Clients.All.applicationRetained(applicationId);
        }
        public void ReleaseApplication(Guid applicationId)
        {
            RetainedApplication temp;
            RetainedApplications.TryRemove(applicationId, out temp);
            Clients.All.applicationReleased(applicationId);
        }
        public ICollection<Guid> GetRetainedApplicationIds()
        {
            return RetainedApplications.Keys;
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            RetainedApplication temp;
            var applicationId = RetainedApplications.Single(x => x.Value.ConnectionId == Context.ConnectionId).Key;
            RetainedApplications.TryRemove(applicationId, out temp);
            Clients.All.applicationReleased(applicationId);
            return base.OnDisconnected(stopCalled);
        }
    }
    public class RetainedApplication
    {
        public string ConnectionId { get; set; }
        public Guid PersonId { get; set; }
    }
