    By letting each decorator implement a `IDecorator` interface that allows access to the decoratee (just as done [here][1]) you can traverse the decorator chain and find the actual implementation type:
        public interface IDecorator
        {
            object Decoratee { get; }
        }
        public static class DecoratorHelpers
        {
            public static IEnumerable<object> GetDecoratorChain(IDecorator decorator)
            {
                while (decorator != null)
                {
                    yield return decorator;
                    decorator = decorator.Decoratee as IDecorator;
                }
            }
        }
    You can implement your decorators with this interface as follows:
        public class SomeDecorator<T> : IInstructionHandler<T>, IDecorator
        {
            private readonly IInstructionHandler<T> decoratee;
            public SomeDecorator(IInstructionHandler<T> decoratee)
            {
                this.decoratee = decoratee;
            }
            object IDecorator.Decoratee { get { return this.decoratee; } }
        }
     When you implemented this interface on all your decorators, you will be able to do this:
         var implementationTypes =
             from handler in container.GetAllInstances<IInstructionHandler<RenderWord>>()
             let mostInnerDecorator =
                 DecoratorHelpers.GetDecoratorChain(handler as IDecorator).LastOrDefault()
             let implementation = mostInnerDecorator != null ? mostInnerDecorator.Decoratee : handler
             select implementation.GetType()
