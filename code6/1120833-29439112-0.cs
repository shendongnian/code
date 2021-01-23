    public static class Component
    {
        public static void Method<TEnum>() where TEnum : DependencyLifecycle
        {
            if (typeof(TEnum) == typeof(SingleInstanceDependencyLifecycle))
            {
                // do something with SingleInstance
            }
        }
    }
    public abstract class DependencyLifecycle { }
    public sealed class SingleInstanceDependencyLifecycle : DependencyLifecycle { }
    public sealed class DoubleInstanceDependencyLifecycle : DependencyLifecycle { }
