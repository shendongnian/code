    public class RegistrationA : ISimpleInjectorRegistration
    {
    	public void Register(Container container)
    	{
    		container.Register<IOne, One>();
    		container.Register<ITwo, Two>();
    		container.Register<ICommon, CommonA>();
    		container.RegisterAll<ICommon>(typeof(CommonA));
    	}
    }
