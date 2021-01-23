    public class RegistrationB : ISimpleInjectorRegistration
    {
    	public void Register(Container container)
    	{
    		container.Register<IThree, Three>();
    		container.Register<IFour, Four>();
    		container.Register<ICommon, CommonB>();
    		container.RegisterAll<ICommon>(typeof (CommonB));
    	}
    }
