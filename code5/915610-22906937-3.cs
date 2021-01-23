    public class CompositionRoot : DefaultControllerFactory {
        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType) {
            if (controllerType == typeof(OrdersController)) {
                var connection = new Ajx.Dal.DapperConnection().getConnection();
                RegisterForDisposal(connection);
                return new OrdersController(
                    new OrdersService(
                        new OrdersRepository(
                            connection)));
            } 
            else if (...) {
                // other controller here.
            } 
            else {
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }
        public static void CleanUpRequest() }
            var items = (List<IDisposable>)HttpContext.Current.Items["resources"];
            if (items != null) items.ForEach(item => item.Dispose());
        }
        private static void RegisterForDisposal(IDisposable instance) {
            var items = (List<IDisposable>)HttpContext.Current.Items["resources"];
            if (items == null) {
                HttpContext.Current.Items["resources"] =
                    items = new List<IDisposable>();
            }
            items.Add(instance);
        }
    }
