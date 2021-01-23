        public class ExportAttributeBindingGenerator : IBindingGenerator
        {
            public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
            {
                var attribute = type.GetCustomAttribute<ExportAttribute>();
                var serviceType = attribute.ServiceInterface;
                if (!serviceType.IsAssignableFrom(type))
                {
                    throw new Exception(string.Format("Error in ExportAttribute: Cannot bind type '{0}' to type '{1}'.", 
                        serviceType, type));
                }
                var binding = bindingRoot.Bind(serviceType).To(type);
                switch (attribute.Scope)
                {
                    case ExportScope.Singleton:
                        yield return (IBindingWhenInNamedWithOrOnSyntax<object>) binding.InSingletonScope();
                        break;
                    case ExportScope.Transient:
                        yield return (IBindingWhenInNamedWithOrOnSyntax<object>) binding.InTransientScope();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
