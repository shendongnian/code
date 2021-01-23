    public class GenericPropertyContractResolver :
          CamelCasePropertyNamesContractResolver
    {
        private readonly Type genericTypeDefinition;
    
        public GenericPropertyContractResolver(Type genericTypeDefinition)
        {
            this.genericTypeDefinition = genericTypeDefinition;
        }
        
        protected override JsonProperty CreateProperty(
            MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty baseProperty =
                base.CreateProperty(member, memberSerialization);
            Type declaringType = member.DeclaringType;
            
            if (!declaringType.IsGenericType ||
                declaringType.GetGenericTypeDefinition() != this.genericTypeDefinition)
            {
                return baseProperty;
            }
            
            Type declaringGenericType = declaringType.GetGenericArguments()[0];
            
            if (IsGenericMember(member))
            {
                baseProperty.PropertyName =
                    this.ResolvePropertyName(declaringGenericType.Name);
            }
            
            return baseProperty;
        }
        
        // Is there a better way to do this? Determines if the member passed in
        // is a generic member in the open generic type.
        public bool IsGenericMember(MemberInfo member)
        {
            MemberInfo genericMember = 
                this.genericTypeDefinition.GetMember(member.Name)[0];
            
            if (genericMember != null)
            {
                if (genericMember.MemberType == MemberTypes.Field)
                {
                    return ((FieldInfo)genericMember).FieldType.IsGenericParameter;
                }
                else if (genericMember.MemberType == MemberTypes.Property)
                {
                    PropertyInfo property = (PropertyInfo)genericMember;
                    
                    return property
                        .GetMethod
                        .ReturnParameter
                        .ParameterType
                        .IsGenericParameter;
                }
            }
            
            return false;
        }
    }
