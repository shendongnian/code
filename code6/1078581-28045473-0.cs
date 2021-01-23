    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            
        }
        public static void SetAndReg()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MyViewModel>();
        }
        public MyViewModel MyVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MyViewModel>();
            }
        }
        public static void Cleanup() {}
    }
