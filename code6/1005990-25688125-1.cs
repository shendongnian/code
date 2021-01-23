    public abstract class BaseViewModel {
        // ...
    }
    public class FirstViewModel : BaseViewModel {
        // ...
    }
    public class SecondViewModel : BaseViewModel {
        private readonly ISomeDependency _injectedDependency;
        public SeoncdViewModel(ISomeDependency dependency) {
            _injectedDependency = dependency;
        }
    }
