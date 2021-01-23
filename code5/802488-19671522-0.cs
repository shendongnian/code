    namespace RC.Common.Core.ProcessPlugin
    {
        // Place directly in namespace
        // public class Contracts
        // {
            public interface IProcessPlugin
            {
                void RunProcess(int jobID);
            }
            public interface IProcessMetaData
            {
                string Process { get; }
            }
        // }
    }
