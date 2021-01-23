    namespace Store.Web.Ninject
    {
        public class NinjectControllerFactory : DefaultControllerFactory
        {
            private IKernel ninjectKernel;
            public NinjectControllerFactory()
            {
                 ninjectKernel = new StandardKernel();
                AddBinding();
            }
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                //return base.GetControllerInstance(requestContext, controllerType);
                return controllerType == null
                    ? null
                    : (IController)ninjectKernel.Get(controllerType);
           }
            private void AddBinding()
            {
                //TODO FR: Step 4 - Add your interface and repository to the bindings
                ninjectKernel.Bind<IProduct>().To<ProductRepository>();
                ninjectKernel.Bind<IInvoice>().To<InvoiceRepository>();
                // Add this, assuming there isn't an interface for your service
                ninjectKernel.Bind<InvoiceBL>().ToSelf();            
            }
        }
    }
