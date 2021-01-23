            container.RegisterType<ISubmittingService, GnipSubmittingService>(
                new DisposingTransientLifetimeManager(),
                new InjectionConstructor(
                    typeof (IGnipHistoricConnection),
                    typeof (IUserDataInterface),
                    new EstimateVerboseLoggingService.TitleBuilder(),
                    new EstimateVerboseLoggingService.FixedEndDateBuilder(),
                    typeof (ISendEmailService),
                    addresses,
                    typeof (ILog)
                    )
                );
            container.RegisterType<IEstimateService, EstimateVerboseLoggingService>(
                new DisposingTransientLifetimeManager(),
                new InjectionConstructor(
                    typeof(IEstimateDataInterface),
                    typeof(ISubmittingService),
                    typeof(ILog)
                    )
                );
...
        public EstimateVerboseLoggingService(
            IEstimateDataInterface estimateData,
            ISubmittingService submittingService,
            ILog log)
        {
            _estimateData = estimateData;
            _submittingService = submittingService;
            _log = log;
        }
