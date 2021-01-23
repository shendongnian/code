    public interface OrderingService// application layer
    {
        void PlaceOder(Order order) {
              //delegate to identity subdomain to validate user request
              UserAuthenticationService.Authenticate(ExtractFrom(order));
              //delegate to booking core domain to handle core business 
              BookingService.placeOrder(order);
        }
    }
