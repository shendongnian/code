    public class DependsOnAttribute : Attribute { ... }
    [PSerializable]
    [IntroduceInterface(typeof(INotifyPropertyChanged))]
    public class NotifyPropertyChangedAspect : InstanceLevelAspect, IAspectProvider, INotifyPropertyChanged
    {
        IEnumerable<AspectInstance> IAspectProvider.ProvideAspects(object targetElement)
        {
            // targetElement is Type, go through it's properties and provide SetterInterceptionAspect to them
        }
        public override void CompileTimeInitialize( Type type, AspectInfo aspectInfo )
        {
            // scan for [DependsOn] here
        }
        [PSerializable]
        public class SetterInterceptionAspect : OnMethodBoundaryAspect
        {
            // ...
            public override void OnExit(MethodExecutionArgs args)
            {
                // fire PropertyChanged event here
            }
            // ...
        }
        // ...
    }
