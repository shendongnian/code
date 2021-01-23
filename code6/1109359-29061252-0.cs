    var stack = new StackTrace(true);
    var thisFrame = stack.GetFrame(0); // ExternalResource constructor
    var parentFrame = stack.GetFrame(1); // Sound constructor
    var grandparentFrame = stack.GetFrame(2); // This is the one!
    var invokingMethod = grandparentFrame.GetMethod();
    var callingAssembly = invokingMethod.Module.Assembly;
