     // Configure SNAP to look at all assemblies starting with the "ConsoleApplication1"  namespace.
    // Next, tell SNAP to intercept any code decorated with a DemoLoggingAttribute by running
    // an instance of the DemoLoggingInterceptor class.
    SnapConfiguration.For<StructureMapAspectContainer>(c =>
        {
            // Tell SNAP to only be concerned with stuff starting with this namespace.
            c.IncludeNamespace("ConsoleApplication1*");
            // Tell SNAP to intercept any method or class decorated with    "DemoLoggingAttribute"
            // by wrapping execution in your own DemoInterceptor class.
            c.Bind<DemoLoggingInterceptor>().To<DemoLoggingAttribute>();
        });
      // Configure StructureMap as usual.
      ObjectFactory.Configure(c => c.For<ISampleClass>().Use<SampleClass>());
     // Use your own class to handle interception.  Logging is a good example.
     public class DemoLoggingInterceptor : MethodInterceptor
     {
         public override void InterceptMethod(IInvocation invocation, MethodBase method, Attribute attribute)
         {
         // Log something important here.
         // Then continue executing your method.
         invocation.Proceed();
         }
     }
