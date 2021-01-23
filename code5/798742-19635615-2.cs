    using System.ComponentModel.Composition;
    namespace MefPlugin
    {
        [Export]
        public class Class2 : MefContracts.IPlugin
        {
            [Import(typeof(MefContracts.IHost))]
            public MefContracts.IHost Host;
    
            public String Work(String input)
            {
                return "Plugin Called. Host Application Version: " + input + Host.Version;
            }
        }
    }
