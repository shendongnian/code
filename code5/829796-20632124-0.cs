       internal class BusinessBaseContractResolver : DefaultContractResolver
       {
            public BusinessBaseContractResolver()
            {
                this.DefaultMembersSearchFlags |= BindingFlags.NonPublic;    
            }
    
            public override JsonContract ResolveContract(Type type)
            {
                JsonContract contract = base.ResolveContract(type);
                if (typeof(BusinessObjectBase).IsAssignableFrom(type))
                {
                    contract.DefaultCreator = delegate
                    {
                        var businessObject = type.CreateUsingDeserializationConstructor<BusinessObjectBase>();
                        businessObject.Initialize(true);
    
                        return businessObject;
                    };
                }
    
                return contract;
            }
        }
