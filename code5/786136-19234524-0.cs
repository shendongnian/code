    public TNestedInterface GetNestedInterface<TNestedInterface>()
        where TNestedInterface : 
			NestedInterfaceTest, 
			INestedInterfaceTest<TNestedInterface>, // new
			new()
    {
        return GateWay<TNestedInterface>.GetNestedInterface();
    }
