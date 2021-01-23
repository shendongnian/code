    public class RepositoryFactorySelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            return (method.Name.EndsWith("ById") && arguments.Length >= 1 && arguments[0] is int)
                       ? string.Format("Repository{0}", arguments[0]) 
                       : base.GetComponentName(method, arguments);
        }
    }
