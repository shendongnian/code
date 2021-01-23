    using System.ComponentModel.Composition;
    namespace MefContracts
    {
        [InheritedExport]
        public interface IPlugin
        {
            String Work(String input);
        }
    
        [InheritedExport]
        public interface IHost
        {
            string Version { get; }
        }
    }
