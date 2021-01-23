    [PSerializable]
    class EquatableAttribute : InstanceLevelAspect, IAdviceProvider
    {
       
        public List<ILocationBinding> Fields;
            
        [ImportMember("Equals", IsRequired = true, Order = ImportMemberOrder.BeforeIntroductions)]
        public Func<object, bool> EqualsBaseMethod;
        [IntroduceMember(IsVirtual = true, OverrideAction = MemberOverrideAction.OverrideOrFail)]
        public new bool Equals(object other)
        {
            // TODO: Define a smarter way to determine if base.Equals should be invoked.
            if (this.EqualsBaseMethod.Method.DeclaringType != typeof(object) )
            {
                if (!this.EqualsBaseMethod(other))
                    return false;
            }
            object instance = this.Instance;
            foreach (ILocationBinding binding in this.Fields)
            {
                // The following code is inefficient because it boxes all fields. There is currently no workaround.
                object thisFieldValue = binding.GetValue(ref instance, Arguments.Empty);
                object otherFieldValue = binding.GetValue(ref other, Arguments.Empty);
                if (!object.Equals(thisFieldValue, otherFieldValue))
                    return false;
            }
            return true;
        }
        // TODO: Implement GetHashCode the same way.
        public IEnumerable<AdviceInstance> ProvideAdvices(object targetElement)
        {
            Type targetType = (Type) targetElement;
            FieldInfo bindingField = this.GetType().GetField("Fields");
            foreach (
                FieldInfo field in
                    targetType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public |
                                         BindingFlags.NonPublic))
            {
                yield return new ImportLocationAdviceInstance(bindingField, new LocationInfo(field));
            }
        }
    }
