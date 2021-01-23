    public class CaliburnRegistrationService : IRegistrationService
    {
        SimpleContainer _container;
        public CaliburnRegistrationService(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;
        }
        public void Register(IResolver resolver)
        {
            // register you stuff based on interface implementation
        }
    }
