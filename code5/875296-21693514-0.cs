    public void GetParameters(Func<ReportUri, SessionContext, IList<Parameter>> returnStuff)
        {
            for (int i = 0; i < 100; i++)
            {
                Log.Message(TraceEventType.Information, "Start of {0} sequential iteration with 5 parallel stress runs".InvariantFormat(i));
                Parallel.For(0, 2, parameterIteration =>
                {
                    Log.Message(TraceEventType.Information, "Stress run count : {0}".InvariantFormat(parameterIteration + 1));
                    string reportUrl = TeamFoundationTestConfig.TeamFoundationReportPath("TaskGroupStatus");
                    ReportUri reportUri = ReportUri.Create(reportUrl);
                    Log.Message(TraceEventType.Information, "ReportUri = {0}".InvariantFormat(reportUri.UriString));
                    IList<Parameter> parameters = returnStuff(reportUri, SessionContext);
                });
            }
        }
