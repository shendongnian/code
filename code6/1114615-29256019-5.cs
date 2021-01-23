    public static void RegisterTypes(IUnityContainer container)
            {
                // .... registrations are here as usual 
    			GetSpecializedDependencyForB.CreateSpecializedDependencyForB = CreateMyDomainService;
    		}
		
