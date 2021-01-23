    public class CompositionRoot : DefaultControllerFactory {
        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType) {
            if (controllerType == typeof(OrdersController)) {
                var connection = new Ajx.Dal.DapperConnection().getConnection();
                return new OrdersController(
                    new OrdersService(
                        new OrdersRepository(
                            Disposable(connection))));
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
        private static T Disposable<T>(T instance) 
            where T : IDisposable {
            var items = (List<IDisposable>)HttpContext.Current.Items["resources"];
            if (items == null) {
                HttpContext.Current.Items["resources"] =
                    items = new List<IDisposable>();
            }
            items.Add(instance);
            return instance;
        }
    }
