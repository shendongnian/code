    public interface IPerRequestScopedService : IDisposable
    {
        string ClientId { get; set; }
    }
    public class PerRequestScopedService : IPerRequestScopedService
    {
        public string ClientId { get; set; }
        public void Dispose()
        {
            Trace.TraceInformation("Object {0} disposed", this.GetType().Name);
        }
    }
