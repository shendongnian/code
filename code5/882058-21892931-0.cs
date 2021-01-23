    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IType1>().To<MyFirstType>();
            Bind<IType2>().To<MySecondType>();
            Bind<IType3>().To<MyThirdType>();
            foreach (var binding in Bindings)
            {
                AssignedWhenInjectedInto<MyClass>(binding);
            }
        }
        public void AssignedWhenInjectedInto<T>(IBinding binding)
        {
            var parent = typeof (T);
            //Copied from Ninject's WhenInjectedInto<T> implementation
            if (parent.IsGenericTypeDefinition)
            {
                if (parent.IsInterface)
                {
                    binding.BindingConfiguration.Condition = r =>
                        r.Target != null &&
                        r.Target.Member.ReflectedType.GetInterfaces().Any(i =>
                            i.IsGenericType &&
                            i.GetGenericTypeDefinition() == parent);
                }
                else
                {
                    binding.BindingConfiguration.Condition = r =>
                        r.Target != null &&
                        r.Target.Member.ReflectedType.GetAllBaseTypes().Any(i =>
                            i.IsGenericType &&
                            i.GetGenericTypeDefinition() == parent);
                }
            }
            else
            {
                binding.BindingConfiguration.Condition = r => r.Target != null && parent.IsAssignableFrom(r.Target.Member.ReflectedType);
            }
        }
    }
