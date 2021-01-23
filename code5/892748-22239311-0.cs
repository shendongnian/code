    // Equivalent to:
    //
    // SomeDomainEvent eventObject = eventAggregator.GetEvent<SomeDomainEvent>();
    MethodInfo getEventMethod = typeof(IEventAggregator).GetMethod("GetEvent");
    MethodInfo genericGetEventMethod = getEventMethod.MakeGenericMethod(typeof(SomeDomainEvent));
    object eventObject = genericGetEventMethod.Invoke(eventAggregator, null);
    // Now choose the version of "Subscribe" you want to call
    // Equivalent to:
    // 
    // eventObject.Subscribe(MyEventHandler);
    Type[] subscribeTypes = new Type[] { typeof(Action<SomeDomainEventArgs>) });
    MethodInfo subscribeMethod = eventObject.GetType().GetMethod("Subscribe", subscribeTypes);
    subscribeMethod.Invoke(eventObject, new object[] { new Action<SomeDomainEventArgs>(MyEventHandler) });
