    public class Program
    {
        private static void Main()
        {
            IUnityContainer container = new UnityContainer();
            // Enable the interception extension.
            container.AddNewExtension<Interception>();
            // Registering as a singleton (container controlled) so I can run a test easily.
            //   Evaluate the lifetime that meets your needs.
            container.RegisterType<IAuthenticationValidator, MyAuthenticationValidator>
                (new ContainerControlledLifetimeManager());
            container.RegisterType<AuthenticationBehavior>();
            // Effectively opt-in to allow interception to occur on this type using InterfaceInterceptor.
            //   Other options exist (TransparentProxyInterceptor and VirtualMethodInterceptor), so 
            //   evaluate these options carefully.
            // And also register the authentication behavior to run on the methods of this type.
            //   There are other ways to hook up your behavior to the types (such as by attribute or by policy).
            //   Evaluate these options to find one that best meets your needs.
            container.RegisterType<IRequiresAuthentication, MyRequiresAuthentication>
                (new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<AuthenticationBehavior>());
            var authenticationValidator = container.Resolve<MyAuthenticationValidator>();
            var requiresAuthentication = container.Resolve<IRequiresAuthentication>();
            // Fake the first call as a passed authentication validation.
            authenticationValidator.IsValid = true;
            requiresAuthentication.SensitiveMethodA();
            // Fake the second call as a failed authentication validation.
            authenticationValidator.IsValid = false;
            // A SecurityException is thrown on this line before the actual method is called.
            requiresAuthentication.SensitiveMethodB();
        }
    }
    public interface IRequiresAuthentication
    {
        void SensitiveMethodA();
        void SensitiveMethodB();
    }
    public class MyRequiresAuthentication : IRequiresAuthentication
    {
        public void SensitiveMethodA() { /* Do something that requires authentication here. */ }
        public void SensitiveMethodB() { /* Do something that requires authentication here. */ }
    }
    public interface IAuthenticationValidator
    {
        // Throws SecurityException if not valid.
        void Validate();
    }
    public class MyAuthenticationValidator : IAuthenticationValidator
    {
        public MyAuthenticationValidator() { IsValid = true; }
        public bool IsValid { get; set; }
        // Throws SecurityException if not valid.
        public void Validate()
        {
            // TODO: Replace this with actual validation logic.
            if (!IsValid)
                throw new SecurityException("Authentication failed!");
        }
    }
    public class AuthenticationBehavior : IInterceptionBehavior
    {
        private readonly IAuthenticationValidator _validator;
        public AuthenticationBehavior(IAuthenticationValidator validator)
        {
            if (validator == null) throw new ArgumentNullException("validator");
            _validator = validator;
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            try
            {
                // Call the validator.
                _validator.Validate();
            }
            catch (SecurityException exception)
            {
                // Be careful to return the exception and not throw it.
                // (Throwing an exception within a behavior can cause other behaviors to be skipped.)
                return new VirtualMethodReturn(input, exception);
            }
            // Behaviors can do anything you want before the actual method call by putting logic here.
            // Call the next behavior in the chain (or the actual method if this is the last behavior in the chain).
            return getNext()(input, getNext);
            // Behaviors can do anything you want after the actual method call by putting logic here.
        }
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            // Let registration determine which types this behavior executes on.
            return Type.EmptyTypes;
        }
        public bool WillExecute
        {
            // Let registration determine when this will execute.
            get { return true; }
        }
    }
