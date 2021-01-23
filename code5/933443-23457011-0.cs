    public interface IInterceptorBindingDefinition<TTarget>
    { 
         Type InterceptorType { get; }
    }
    public class InterceptorBindingDefinition<TTarget, TInterceptor> : IInterceptorBindingDefinition<TTarget>
      where TInterceptor : IInterceptor
    {
         Type InterceptorType { get { return typeof(TInterceptor); } }
    }
    IBindingRoot
      .Bind<IInterceptorBindingDefinition<IFoo>>()
      .To<InterceptorBindingDefinition<TTarget, LoggingInterceptor>();
    IBindingRoot
      .Bind<IInterceptorBindingDefinition<IFoo>>()
      .To<InterceptorBindingDefinition<TTarget, SomeOtherInterceptor>();      
