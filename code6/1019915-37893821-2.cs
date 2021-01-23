    public class ForcedObjectResolver : DefaultContractResolver
    {
        public override JsonContract ResolveContract(Type type)
        {
            // We're going to null the converter to force it to serialize this as a plain object.
            var contract =  base.ResolveContract(type);
            contract.Converter = null;
            return contract;
        }
    }
    
