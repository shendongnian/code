    public interface IViewModelFactory {
        T Create<T>() where T : BaseViewModel;
    }
    public class ViewModelFactory : IViewModelFactory {
        private readonly Dictionary<Type, Func<BaseViewModel>> _factories;
        public ViewModelFactory(Dictionary<Type, Func<BaseViewModel>> factories) {
            _factories = factories;
        }
        public T Create<T>() where T : BaseViewModel {
            return _factories[typeof (T)]() as T;
        }
    }
