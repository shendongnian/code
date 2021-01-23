    public static void RegisterTypes(IUnityContainer container)
            {
                // .... registrations are here as usual 
    			SpecializedDependencyForB.CreateSpecializedDependencyForB = CreateMyDomainService;
    		}
		
