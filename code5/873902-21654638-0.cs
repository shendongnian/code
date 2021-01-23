       ManualResetEvent signal = new ManualResetEvent(false);
    for (int handleIndex = 0; handleIndex < 50; ++handleIndex)
        {
           
    
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
                {
                    string reportUrl = TeamFoundationTestConfig.TeamFoundationReportPath("TaskGroupStatus");
                    ReportUri reportUri = ReportUri.Create(reportUrl);
                    Log.Message(TraceEventType.Information, "ReportUri = {0}".InvariantFormat(reportUri.UriString));
                    IList<Parameter> parameters = this.RemoteReportingServiceFactory.CreateReportParameterProvider().GetParameters(reportUri, SessionContext);
                    Assert.IsNotNull(parameters, "Assertion failed: Parameters cannot be null. GetParameters failed");
                    Assert.IsTrue(parameters.Count > 0, "Assertion failed: No parameters available on the report page. GetParameters failed. Count = {0}".InvariantFormat(parameters.Count));
                    if (Interlocked.Decrement(ref toProcess) == 0)
                    {
                        signal.Set();
                    }
                }), null);
   
            
        }   
        signal.WaitOne();
