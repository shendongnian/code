    public class CustomerHandler : MyServiceBaseWithEnversSupport
    {
        public object Get(ListCustomers request)
        {
            // You can then access the instance in the scope of the request
            // So you now have access to the current user identity
            Envers.Username = Session.Username; // Just an example modify as required.
        }
    }
