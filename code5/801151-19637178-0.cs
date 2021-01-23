    public class PluginFactorySelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            return (method.Name.EndsWith("ById") && arguments.Length >= 1 && arguments[0] is string)
                ? (string) arguments[0]
                : base.GetComponentName(method, arguments);
        }
    }
