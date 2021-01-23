    static ViewModelLocator()
        {
            var container = new UnityContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocatorAdapter(container));
            container.RegisterInstance<ILoggingService>(new ConsoleLoggingService());
            container.RegisterInstance<IMessageBoxService>(new SimpleMessageBoxService());
            container.RegisterInstance<ITestSuiteService>(new TestSuiteService());
            container.RegisterInstance<IApplicationService>(new ApplicationService());
        }
        /// <summary>
        /// Gets the <see cref="BackstageAboutViewModel"/>.
        /// </summary>
        public BackstageAboutViewModel BackstageAboutViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BackstageAboutViewModel>();
            }
        }
