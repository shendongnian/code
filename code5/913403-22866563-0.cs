    [MulticastAttributeUsage(
        MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.Field,
        TargetTypeAttributes = MulticastAttributes.UserGenerated,
        TargetMemberAttributes = (MulticastAttributes.AnyVisibility & ~MulticastAttributes.Private) | MulticastAttributes.UserGenerated)]
    [AttributeUsage(
        AttributeTargets.Assembly |
        AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Delegate,
        AllowMultiple = true)]
    public class GrantAccessAttribute : ReferentialConstraint
    {
        private string[] namespaces;
        public GrantAccessAttribute(params Type[] types)
        {
            this.namespaces = types.Select(t => t.Namespace).ToArray();
        }
        public override void ValidateCode(object target, Assembly assembly)
        {
            MemberInfo targetMember = target as MemberInfo;
            if (targetMember != null)
            {
                Type targetType = target as Type;
                
                if (targetType != null)
                {
                    // validate derived types
                    foreach (TypeInheritanceCodeReference reference in ReflectionSearch.GetDerivedTypes(targetType, ReflectionSearchOptions.IncludeTypeElement))
                    {
                        Validate(reference);
                    }
                    // validate member references
                    foreach (MemberTypeCodeReference reference in ReflectionSearch.GetMembersOfType(targetType, ReflectionSearchOptions.IncludeTypeElement))
                    {
                        Validate(reference);
                    }
                }
                // validate references in methods
                foreach (MethodUsageCodeReference methodUsageCodeReference in ReflectionSearch.GetMethodsUsingDeclaration(targetMember))
                {
                    Validate(methodUsageCodeReference);
                }
            }
        }
        private void Validate(ICodeReference codeReference)
        {
            string usingNamespace = GetNamespace(codeReference.ReferencingDeclaration);
            string usedNamespace = GetNamespace(codeReference.ReferencedDeclaration);
            
            if (usingNamespace.Equals(usedNamespace, StringComparison.Ordinal))
                return;
            if (this.namespaces.Any(
                x => usingNamespace.Equals(x, StringComparison.Ordinal) ||
                     (usingNamespace.StartsWith(x, StringComparison.Ordinal) && usingNamespace[x.Length] == '.')))
                return;
            object[] arguments = new object[] {/*...*/};
            Message.Write(MessageLocation.Of(codeReference.ReferencingDeclaration), SeverityType.Warning, "ErrorCode", "Access error message.", arguments);
        }
        private string GetNamespace(object declarationObj)
        {
            Type declaringType = declarationObj as Type;
            if (declaringType == null)
            {
                MemberInfo declaringMember;
                ParameterInfo parameter;
                LocationInfo location;
                
                if ((declaringMember = declarationObj as MemberInfo) != null)
                {
                    declaringType = declaringMember.DeclaringType;
                }
                else if ((location = declarationObj as LocationInfo) != null)
                {
                    declaringType = location.DeclaringType;
                }
                else if ((parameter = declarationObj as ParameterInfo) != null)
                {
                    declaringType = parameter.Member.DeclaringType;
                }
                else
                {
                    throw new Exception("Invalid declaration object.");
                }
            }
            return declaringType.Namespace;
        }
    }
