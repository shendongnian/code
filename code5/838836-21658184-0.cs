    public override JsonContract ResolveContract(Type type) {
        var contract = base.ResolveContract(type);
        contract.IsReference = false;
        return contract;
    }
