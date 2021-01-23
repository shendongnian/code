    [Serializable]
    public sealed class AutoServiceContractAttribute : TypeLevelAspect, IAspectProvider
    {
        // This method is called at build time and should just provide other aspects.
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            Type targetType = (Type)targetElement;
            var introduceServiceContractAspect =
                new CustomAttributeIntroductionAspect( 
                    new ObjectConstruction(typeof(ServiceContractAttribute)
                                              .GetConstructor(Type.EmptyTypes)));
            var introduceOperationContractAspect =
                new CustomAttributeIntroductionAspect( 
                    new ObjectConstruction(typeof(OperationContractAttribute)
                                             .GetConstructor(Type.EmptyTypes)));
            // Add the ServiceContract attribute to the type.
            yield return new AspectInstance(targetType, introduceServiceContractAspect);
            // Add a OperationContract attribute to every relevant method.
            var flags = BindingFlags.Public | BindingFlags.Instance;
            foreach (MethodInfo method in targetType.GetMethods(flags))
            {
                if (!method.IsDefined(typeof(NotOperationContractAttribute), false))
                    yield return new AspectInstance(method, introduceOperationContractAspect);
            }
        }
    }
