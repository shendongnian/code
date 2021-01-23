    public class ViewModelLocator
        {
            private static readonly IKernel _kernel;
            
            static ViewModelLocator()
            {
                _kernel = new StandardKernel();
                if (ViewModelBase.IsInDesignModeStatic)
                {
                     _kernel.Bind<IBasicVM>().To<DesignBasicVm>();
                }
                else
                {
                    _kernel.Bind<IBasicVM>().To<BasicVm>();
                }
            }
    
            public IBasicVM BasicVm { get { return _kernel.Get<IBasicVM>(); } }
        }
