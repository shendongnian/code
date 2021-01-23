    public interface IDirectoryEnumerator
    {
        IEnumerable<IDirectory> GetDirectories();
    }
    public class DirectoryEnumImpl : IDirectoryEnumerator
    {
        private readonly IDirectoryFactory _directoryFactory;
        
        public DirectoryEnumImpl(IDirectoryFactory directoryFactory)
        {
            _directoryFactory = directoryFactory;
        }
        public IEnumberable<IDirectory> GetDirectories()
        {
            // you can use the factory here
        }
    }
    public interface IDirectoryFactory
    {
        IDirectory CreateDirectory(DirectoryType directoryType);
    }
    public class DirectoryFactoryImpl : IDirectoryFactory
    {
        IDirectory CreateDirectory(DirectoryType directoryType)
        {
            if (directoryType == DirectoryType.DIR_A)
                return new Dir_A();
            // the same goes for other types.
        }
    }
    public enum DirectoryType {
        DIR_A, DIR_B, // etc ...
    }
