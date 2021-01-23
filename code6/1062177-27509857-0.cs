    public interface ISystemWrapper
    {
        string MachineName();
    }
    public class SystemWrapper : ISystemWrapper
    {
        public string MachineName()
        {
            return Environment.MachineName;
        }
    }
