    [HasInstallableResourcesAttribute]
    [PerformanceCountersDefinition(counterCategoryName, "LoggingCountersHelpResource")]
    [EventLogDefinition("Application", "Enterprise Library Logging")]
    public class MyLoggingInstrumentationProvider : InstrumentationListener, ILoggingInstrumentationProvider
    {
        static EnterpriseLibraryPerformanceCounterFactory factory = new EnterpriseLibraryPerformanceCounterFactory();
        private const string TotalLoggingEventsRaised = "Total Logging Events Raised";
        private const string TotalTraceListenerEntriesWritten = "Total Trace Listener Entries Written";
        [PerformanceCounter("Logging Events Raised/sec", "LoggingEventRaisedHelpResource", PerformanceCounterType.RateOfCountsPerSecond32)]
        private EnterpriseLibraryPerformanceCounter logEventRaised;
        [PerformanceCounter(TotalLoggingEventsRaised, "TotalLoggingEventsRaisedHelpResource", PerformanceCounterType.NumberOfItems32)]
        private EnterpriseLibraryPerformanceCounter totalLoggingEventsRaised;
        [PerformanceCounter("Trace Listener Entries Written/sec", "TraceListenerEntryWrittenHelpResource", PerformanceCounterType.RateOfCountsPerSecond32)]
        private EnterpriseLibraryPerformanceCounter traceListenerEntryWritten;
        [PerformanceCounter(TotalTraceListenerEntriesWritten, "TotalTraceListenerEntriesWrittenHelpResource", PerformanceCounterType.NumberOfItems32)]
        private EnterpriseLibraryPerformanceCounter totalTraceListenerEntriesWritten;
        private const string counterCategoryName = "Enterprise Library Logging Counters";
        private IEventLogEntryFormatter eventLogEntryFormatter;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingInstrumentationProvider"/> class.
        /// </summary>
        /// <param name="performanceCountersEnabled"><code>true</code> if performance counters should be updated.</param>
        /// <param name="eventLoggingEnabled"><code>true</code> if event log entries should be written.</param>
        /// <param name="applicationInstanceName">The application instance name.</param>
        public MyLoggingInstrumentationProvider(bool performanceCountersEnabled,
                                              bool eventLoggingEnabled,
                                              string applicationInstanceName)
            : base(performanceCountersEnabled, eventLoggingEnabled, new AppDomainNameFormatter(applicationInstanceName))
        {
            this.eventLogEntryFormatter = new EventLogEntryFormatter("Enterprise Library Logging Application Block");//Resources.BlockName);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingInstrumentationProvider"/> class.
        /// </summary>
        /// <param name="instanceName">The instance name.</param>
        /// <param name="performanceCountersEnabled"><code>true</code> if performance counters should be updated.</param>
        /// <param name="eventLoggingEnabled"><code>true</code> if event log entries should be written.</param>
        /// <param name="applicationInstanceName">The application instance name.</param>
        public MyLoggingInstrumentationProvider(string instanceName,
                                              bool performanceCountersEnabled,
                                              bool eventLoggingEnabled,
                                              string applicationInstanceName)
            : base(instanceName, performanceCountersEnabled, eventLoggingEnabled, new AppDomainNameFormatter(applicationInstanceName))
        {
            this.eventLogEntryFormatter = new EventLogEntryFormatter("Enterprise Library Logging Application Block");//Resources.BlockName);
        }
        /// <summary>
        /// Fires the <see cref="LoggingInstrumentationProvider.traceListenerEntryWritten"/> event.
        /// </summary>
        public void FireTraceListenerEntryWrittenEvent()
        {
            if (PerformanceCountersEnabled)
            {
                traceListenerEntryWritten.Increment();
                totalTraceListenerEntriesWritten.Increment();
            }
        }
        ///<summary>
        ///
        ///</summary>
        /// <param name="exception">The exception that describes the reconfiguration error.</param>
        public void FireReconfigurationErrorEvent(Exception exception)
        {
            if (exception == null) throw new ArgumentNullException("exception");
            if (EventLoggingEnabled)
            {
                string entryText = eventLogEntryFormatter.GetEntryText("An unknown error occurred reconfiguring the Logging Application Block. Reconfiguration will not take place."
                //Resources.ReconfigurationFailure
                , exception);
                EventLog.WriteEntry(GetEventSourceName(), entryText, EventLogEntryType.Error);
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="message">A message describing the failure.</param>
        /// <param name="exception">The exception that caused the failure..</param>
        public void FireFailureLoggingErrorEvent(string message, Exception exception)
        {
            if (exception == null) throw new ArgumentNullException("exception");
            if (EventLoggingEnabled)
            {
                string entryText = eventLogEntryFormatter.GetEntryText(message, exception);
                EventLog.WriteEntry(GetEventSourceName(), entryText, EventLogEntryType.Error);
            }
            // New Code to throw an exception
            throw exception;
        }
        /// <summary>
        /// </summary>
        /// <param name="configurationException">The exception that describes the configuration error.</param>
        public void FireConfigurationFailureEvent(Exception configurationException)
        {
            if (configurationException == null) throw new ArgumentNullException("configurationException");
            if (EventLoggingEnabled)
            {
                string entryText = eventLogEntryFormatter.GetEntryText("The error occurred while refreshing the logging configuration. The configuration will not be updated."
                //Resources.ConfigurationFailureUpdating
                , configurationException);
                EventLog.WriteEntry(GetEventSourceName(), entryText, EventLogEntryType.Error);
            }
        }
        /// <summary>
        /// Fires the <see cref="LoggingInstrumentationProvider.logEventRaised"/> event.
        /// </summary>
        public void FireLogEventRaised()
        {
            if (PerformanceCountersEnabled)
            {
                logEventRaised.Increment();
                totalLoggingEventsRaised.Increment();
            }
        }
        /// <summary/>
        /// <param name="message"></param>
        public void FireLockAcquisitionError(string message)
        {
            if (EventLoggingEnabled)
            {
                string entryText = eventLogEntryFormatter.GetEntryText(message);
                EventLog.WriteEntry(GetEventSourceName(), entryText, EventLogEntryType.Error);
            }
        }
        /// <summary>
        /// Creates the performance counters to instrument the logging events to the instance names.
        /// </summary>
        /// <param name="instanceNames">The instance names for the performance counters.</param>
        protected override void CreatePerformanceCounters(string[] instanceNames)
        {
            logEventRaised = factory.CreateCounter(counterCategoryName, "Logging Events Raised/sec", instanceNames);
            traceListenerEntryWritten = factory.CreateCounter(counterCategoryName, "Trace Listener Entries Written/sec", instanceNames);
            totalLoggingEventsRaised = factory.CreateCounter(counterCategoryName, TotalLoggingEventsRaised, instanceNames);
            totalTraceListenerEntriesWritten = factory.CreateCounter(counterCategoryName, TotalTraceListenerEntriesWritten, instanceNames);
        }
    }
