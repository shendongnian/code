    public class NamespaceFilteringMockMissingBindingsResolver : MockMissingBindingResolver
     {
    	public NamespaceFilteringMockMissingBindingsResolver(IMockProviderCallbackProvider mockProviderCallbackProvider)
    		: base(mockProviderCallbackProvider)
    	{
    	}
    
    	protected override bool TypeIsInterfaceOrAbstract(Type service)
    	{
    		return base.TypeIsInterfaceOrAbstract(service) && service.Namespace != null && service.Namespace.StartsWith("YourNamespace");
    	}
     }
     
    public class CustomNSubstituteMockingKernel : NSubstituteMockingKernel
    {
    	public CustomNSubstituteMockingKernel()
    	{
    		this.AddComponents();
    	}
    
    	public CustomNSubstituteMockingKernel(INinjectSettings settings, params INinjectModule[] modules)
    		: base(settings, modules)
    	{
    		this.AddComponents();
    	}
    
    	private new void AddComponents()
    	{
    		this.Components.RemoveAll<IMissingBindingResolver>();
    		this.Components.Add<IMissingBindingResolver, SingletonSelfBindingResolver>();
    		this.Components.Add<IMissingBindingResolver, NamespaceFilteringMockMissingBindingsResolver>();
    	}
    }
