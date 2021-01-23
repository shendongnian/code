    public interface ICommandHandler<T> where T : class { }
    public interface IDontUseUnitOfWork { }
    public class MyCommand { }
    public class MyCommandHandler : 
        ICommandHandler<MyCommand>, IDontUseUnitOfWork { }
    public sealed class UnitOfWorkCommandDecorator<T> :
        ICommandHandler<T> where T : class
    {
        public UnitOfWorkCommandDecorator(ICommandHandler<T> decorated) { }
    }
