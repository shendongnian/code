    public static class AutofacExtensions
    {
        private static readonly FieldInfo ContextFieldInfo;
        private static readonly FieldInfo ActivationStackFieldInfo;
        static AutofacExtensions()
        {
            var autofacAssembly = typeof(IInstanceLookup).Assembly;
            Type instanceLookupType = autofacAssembly.GetType("Autofac.Core.Resolving.InstanceLookup");
            ContextFieldInfo = instanceLookupType.GetField("_context", BindingFlags.Instance | BindingFlags.NonPublic);
            Type resolveOperationType = autofacAssembly.GetType("Autofac.Core.Resolving.ResolveOperation");
            ActivationStackFieldInfo = resolveOperationType.GetField("_activationStack", BindingFlags.Instance | BindingFlags.NonPublic);
        }
        public static IResolveOperation Context(this IInstanceLookup instanceLookup)
        {
            return (IResolveOperation)ContextFieldInfo.GetValue(instanceLookup);
        }
        public static IEnumerable<IInstanceLookup> ActivationStack(this IResolveOperation resolveOperation)
        {
            return (IEnumerable<IInstanceLookup>)ActivationStackFieldInfo.GetValue(resolveOperation);
        }
        /// <summary>
        /// Pass parameters from the top level resolve operation (typically a delegate factory call)
        /// to a nested component activation.
        /// </summary>
        public static void ForwardFactoryParameters(PreparingEventArgs e)
        {
            var delegateFactoryActivation = ((IInstanceLookup) e.Context).Context().ActivationStack().Last();
            e.Parameters = e.Parameters.Concat(delegateFactoryActivation.Parameters);
        }
    }
