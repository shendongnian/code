    public class InjectionModuleData : NinjectModule
    {
 
        public override void Load()
        {
            Kernel.Bind<ICustomerData>().To<CustomerData>().InRequestScope();
            Kernel.Bind<IEmployeeData>().To<EmployeeData>().InRequestScope();
        }
    }
