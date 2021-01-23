    var task1 = Task<bool>.Factory.StartNew(() => DoProcess());
    
    successContinuation = task1 .ContinueWith(t1 => updateSuccess(),
                                              TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.ExecuteSynchronously)
    failureContinuation = task1 .ContinueWith( t => updateFault(),
                                              TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
    Task.WaitAny(successContinuation, failureContinuation);
