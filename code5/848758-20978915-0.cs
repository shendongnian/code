    var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();
    
    var permissionSet = new PermissionSet(PermissionState.None);
    permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
    			
    var appDomain = AppDomain.CreateDomain(
    	"Sandboxed",
    	null,
    	new AppDomainSetup { ApplicationBase = CreateFakePath() },
    	permissionSet,
    	currentAssembly.Evidence.GetHostEvidence<StrongName>());
    
    var stub = (Stub)Activator.CreateInstanceFrom(appDomain, currentAssembly.Location, typeof(Stub).FullName).Unwrap();
    
    var hostStub = new HostStub();
    stub.RequestTime(hostStub);
