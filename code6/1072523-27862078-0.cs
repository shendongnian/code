    public interface IAddressProvider {
        string GetAddress(double lat, double long);
    }
    
    public class AddressProviderProxy: IAddressProvider {
    	public AddressProviderProxy(IAddressProvider[] providers) {
    		_providers = providers;
    	}
    	
    	private readonly IAddressProvider[] _providers;
    	
    	string IAddressProvider.GetAddress(double lat, double long) {
    		foreach (var provider in _providers) {
    			string address = provider.GetAddress(lat, long);
    			if (address != null)
    				return address;
    		}
    		return null;
    	}
    }
    
    // Wire up using DI
    container.Register<IAddressProvider>(
    	() => new AddressProviderProxy(
    		new IAddressProvider[3] {
    			cachedAddressProvider,
    			localDbAddressProvider,
    			externalAddressProvider
    		}
    	)
    );
    
    // Use it
    IAddressProvider provider = ...from the container, injected..
    string address = provider.GetAddress(lat, long) ?? "no address found";
