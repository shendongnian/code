    public class CarService : ICarService
    {
    	private ICarRepository Repository { get; set; }
        private IWheelService WheelService { get; set; }
    
        public CarService(ICarRepository repository)
        {
            this.Repository = repository;
        }
    
    	public ICarService WithWheelService(IWheelService service)
    	{
    		// do arguments check
    		if(service == null) throw ...;
    		
    		WheelService = service;
    		return this;
    	}
        public Car Build()
        {
    		return new Car(WheelService, ...);        
        }
    }
