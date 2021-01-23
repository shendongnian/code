    public interface IFactoryDataSourceProvider<T> {
        IList<T> GetData();
    }
    public class IStringListFactory {
        public IList<string> Create(IFactoryDataSourceProvider<string> provider) {
            return _provider.GetData();
        }
    }
