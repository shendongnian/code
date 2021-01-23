    namespace AspectOrientedProgramming
    {
     [Serializable]
        [MulticastAttributeUsage (MulticastTargets.Class)]
        public sealed class DataContractAspect:TypeLevelAspect, IAspectProvider
        {
            public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
            {
                var targetType = (Type) targetElement;
    
                var introduceDataContractAspect =
                    new CustomAttributeIntroductionAspect(
                        new ObjectConstruction(typeof(DataContractAttribute).GetConstructor(Type.EmptyTypes)));
                var introduceDataMemberAspect =
                    new CustomAttributeIntroductionAspect(
                        new ObjectConstruction(typeof(DataMemberAttribute).GetConstructor(Type.EmptyTypes)));
    
                yield return new AspectInstance(targetType, introduceDataContractAspect);
    
                foreach (var property in targetType.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
                {
                    if (property.CanWrite && !property.IsDefined(typeof(NotADataMemberAttribute), false))
                    {
                        yield return new AspectInstance(property, introduceDataMemberAspect);
                    }
                }
            }
        }
    }
