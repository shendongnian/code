    //pseudo code from the top of my head
    var perperationTask = service.PrepareStuffAsync(parameter);  
    var parameterATask = service.GetParameterA(value1, value2);  
    var parameterBTask = service.GetParameterB(value2,value3);  
    
    await Task.WhenAll(settingsTask, reputationTask, activityTask);  
    
    PreperationSettings settings = perperationTask.Result;  
    int parameterAResult = parameterATask.Result;  
    int parameterBResult = parameterBTask.Result;
    
    await calulation = service.CalculateAsync(parameterAResult,parameterBResult);
