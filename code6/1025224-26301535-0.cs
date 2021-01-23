    this.wrapper.InvokeAsync<string, Collection<KeyValuePair<string, string>>, bool>(
                svc => svc.BeginExecuteMyMethod,
                svc => svc.EndExecuteMyMethod,
                "jobname",
                parameters,
                this.ContinuationAction);
