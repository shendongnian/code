    public class ConcreteControllerFactory : IControllerFactory
    {
        public TController CreateControllerAndView<TController>()
        {
            // since you are in the top most layer, you know all types from
            // underlaying layers, including controllers and views
         
            // IoC would help here a lot! But without it:
            if ( typeof<TController> == typeof<UserController> )
            {
                IUserView view = new UIUserView();
                UserController c = new UserController( view );
            }
            ...
        }
    }
