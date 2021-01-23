    [ServiceContract]
    public interface IServiceContract
    {
        [OperationContract]
        string ServiceVersion();
    }
    
    public class Implementation : IServiceContract 
    {
        public string ServiceVersion()
        {
            string assemblyLocation = this.GetType().Assembly.Location;
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assemblyLocation);
            string fileVersion = fvi.FileVersion;
    
            return fileVersion;
        }   
    }
