    static ViewModelLocator()
    {
        /// parts missing for brevity
        SimpleIoc.Default.Register<IDataService, DataService>();
        SimpleIoc.Default.Register<INavigationService, NavigationService>();
        SimpleIoc.Default.Register<ContactsViewModel>();
        SimpleIoc.Default.Register<ConversationViewModel>(true);
    }
