    public class ViewModelLocator
        {
            private static readonly IKernel _kernel;
            
            static ViewModelLocator()
            {
                var kernel = new StandardKernel();
                if (ViewModelBase.IsInDesignModeStatic)
                {
                     kernel.Bind<IBasicVM>().To<DesignBasicVm>();
                }
                else
                {
                    kernel.Bind<IBasicVM>().To<BasicVm>();
                }
                _kernel = kernel;
            }
    
            public IBasicVM BasicVm { get { return _kernel.Get<IBasicVM>(); } }
        }
