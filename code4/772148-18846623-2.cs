     task.ContinueWith(
                t =>
                t.Exception.Handle(ex =>
                                       {
                                           logger.Error(ex.Message, ex);
                                           return false;
                                       })
                , TaskContinuationOptions.OnlyOnFaulted
                );
