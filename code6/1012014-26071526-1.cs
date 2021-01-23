    var response = await base.InvokeAsync<T>(executionContext).ConfigureAwait(false); 
    public override async System.Threading.Tasks.Task<T> InvokeAsync<T>(IExecutionContext executionContext)
            {
                executionContext.RequestContext.Metrics.AddProperty(Metric.AsyncCall, true);
                try
                {
                    executionContext.RequestContext.Metrics.StartEvent(Metric.ClientExecuteTime);
                    var response = await base.InvokeAsync<T>(executionContext).ConfigureAwait(false);    
                    return response;                              
                }
                finally
                {
                    executionContext.RequestContext.Metrics.StopEvent(Metric.ClientExecuteTime);
                    this.LogMetrics(executionContext);
                }            
            }
