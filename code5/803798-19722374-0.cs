    [Subject(typeof(RoutingEngine))]
    public class when_routing_a_message_with_fakes : WithSubject<RoutingEngine>
    {
        Establish that = () =>
        {
            Message = new MyMessage { SomeValue = 1, SomeOtherValue = 11010 };
            The<IMessageRouter>().WhenToldTo(x => x.CanRoute(Message)).Return(true);
            The<IMessageRouters>().WhenToldTo(x => x.Where(Param<Func<IMessageRouter, bool>>.IsAnything))
                .Return(new List<IMessageRouter> { The<IMessageRouter>() });
        };
    
        Because of = () => Subject.Route(Message);
    
        It should_route_the_message = () =>
            The<IMessageRouter>().WasToldTo(x => x.Route(Message));
    
        static MyMessage Message;
    }
