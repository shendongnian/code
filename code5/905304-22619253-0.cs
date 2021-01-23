    namespace MyProject.ViewModels
    {
        public sealed class SessionViewModel : ViewModelBase
        {
            private static readonly SessionViewModel instance = new SessionViewModel();
            public static SessionViewModel Instance
            {
                get { return instance; }
            }
            
            private List<IModule> modulesOpen;
            public List<IModule> ModulesOpen
            {
                get { return modulesOpen; }
                set
                {
                    modulesOpen = value;
                    NotifyPropertyChanged(() => ModulesOpen);
                }
            }
        }
        
        public static IModule GetModuleInstance(string moduleName)
        {
            string finalName = "MyProject.ViewModels." + moduleName + "ViewModel";
            IModule moduleToOpen = null;
            if (Instance.ModulesOpen != null)
            {
                moduleToOpen = Instance.ModulesOpen.SingleOrDefault(mod => mod.ModuleName == moduleName);
            }
            else
            {
                Instance.ModulesOpen = new List<IModule>();
            }
            if (moduleToOpen != null) return moduleToOpen;
            Type module = Type.GetType(finalName);
            moduleToOpen = (IModule) Activator.CreateInstance(module);
            Instance.ModulesOpen.Add(moduleToOpen);
            return moduleToOpen;
        }
        
        public class UsageExample()
        {
            var vm = SessionViewModel.GetModuleInstance("MyVMName");
            ((MyVMName)vm).MyVMPropertyName;
        }
    }
