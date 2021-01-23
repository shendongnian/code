    public class InjectionModuleBiz : NinjectModule
    {
 
        public override void Load()
        {
            Kernel.Bind<ICustomerBiz>().To<CustomerBiz>().InRequestScope();
            Kernel.Bind<IEmployeeBiz>().To<EmployeeBiz>().InRequestScope();
        }
    }
