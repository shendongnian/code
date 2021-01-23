    public class ViewModelLocator {
        static ViewModelLocator() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<DataFromADVM>();
        }
        public RandomName DataFromADVM {
            get {
                return ServiceLocator.Current.GetInstance<DataFromADVM>();
            }
        }
    }
