    Assembly asm = Assembly.GetExecutingAssembly();
    Type remoteControlType = asm.GetType("WindowsFormsApplication1.RemoteControl");
    object remote = Activator.CreateInstance(remoteControlType);
    
    var methodInfo = remoteControlType.GetMethod("Push");
    var remoteButtons = methodInfo.GetParameters()[0];
    // .Net 4.0    
    // var enumVals = remoteButtons.ParameterType.GetEnumValues();
    
    // .Net 3.5
    var enumVals = Enum.GetValues(remoteButtons.ParameterType);
    methodInfo.Invoke(remote, new object[] { enumVals.GetValue(0) });   //Play
    methodInfo.Invoke(remote, new object[] { enumVals.GetValue(1) }); //Pause
    methodInfo.Invoke(remote, new object[] { enumVals.GetValue(2) }); //Stop
