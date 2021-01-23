    namespace System.ServiceModel.Routing
    {
        // Summary:
        //     Defines the routing service, which is responsible for routing messages between
        //     endpoints based on filter criteria.
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any, InstanceContextMode = InstanceContextMode.PerSession, UseSynchronizationContext = false, ValidateMustUnderstand = false)]
        public sealed class RoutingService : ISimplexDatagramRouter, ISimplexSessionRouter, IRequestReplyRouter, IDuplexSessionRouter, IDisposable
        {
        }
    }
