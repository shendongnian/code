	static ICarFactory GetFactory()
    {
        string userLocation;
        userLocation = "Hamburg"; //Get user location from user settings
		//try get specific factory for location
		if(_container.IsRegistered<ICarFactory>(userLocation)){			
			return _container.Resolve<ICarFactory>(userLocation);
		}
		//if not found, get default factory
		return _container.Resolve<ICarFactory>();	
    }
