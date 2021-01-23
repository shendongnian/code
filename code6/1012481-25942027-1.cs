    // get a delegate for the actual handler
	var delegateType = typeof(Func<,>).MakeGenericType(handlerParamType, handlerReturnType);
	var del = Delegate.CreateDelegate(delegateType, handlerMethod);
	// get a Func that wraps that handler in a tracer handler
    var RqRsAsyncHandlerMethodInfo = typeof(Container).GetMethod("RqRsAsyncHandler");
	var RqRsAsyncHandlerMethodInfoGeneric = RqRsAsyncHandlerMethodInfo.MakeGenericMethod(handlerParamType, handlerReturnType);
	var wrapperFunc = RqRsAsyncHandlereMethodInfoGeneric.Invoke(null, new object[] { del });
	// get the eventHandlers method
	MethodInfo respondMethod = typeof(EventHandlers).GetMethod("RespondAsync");
	MethodInfo genericRespondMethod = respondMethod.MakeGenericMethod(new[] { handlerParamType, handlerReturnType });
	// invoke the Bus method
	genericRespondMethod.Invoke(eventHandlers , new[] { wrapperFunc });
