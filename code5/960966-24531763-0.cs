    2/07/2014 14:53:10:
    System.Reflection.TargetInvocationException: Het doel van een aanroep heeft een uitzondering veroorzaakt. ---> System.MissingMethodException: Er is geen paramet
    erloze constructor voor dit object opgegeven.
       bij System.RuntimeTypeHandle.CreateInstance(RuntimeType type, Boolean publicOnly, Boolean noCheck, Boolean& canBeCached, RuntimeMethodHandleInternal& ctor, B
    oolean& bNeedSecurityCheck)
       bij System.RuntimeType.CreateInstanceSlow(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, StackCrawlMark& stackMark)
       bij System.RuntimeType.CreateInstanceDefaultCtor(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, StackCrawlMark& stackMark)
       bij System.Activator.CreateInstance(Type type, Boolean nonPublic)
       bij System.Activator.CreateInstance(Type type)
       bij Rebus.SimpleHandlerActivator.<>c__DisplayClass1.<Register>b__0()
       bij Rebus.SimpleHandlerActivator.<GetHandlerInstancesFor>b__b[T](Func`1 f)
       bij System.Linq.Enumerable.WhereSelectListIterator`2.MoveNext()
       bij System.Linq.Enumerable.<CastIterator>d__b1`1.MoveNext()
       bij System.Linq.Buffer`1..ctor(IEnumerable`1 source)
       bij System.Linq.Enumerable.ToArray[TSource](IEnumerable`1 source)
       bij Rebus.SimpleHandlerActivator.GetHandlerInstancesFor[T]()
       bij Rebus.Configuration.BuiltinContainerAdapter.GetHandlerInstancesFor[T]()
       --- Einde van intern uitzonderingsstackpad ---
       bij System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
       bij System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
       bij System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
       bij System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
       bij Rebus.Bus.Dispatcher.GetHandlerInstances(Type messageType)
       bij System.Linq.Enumerable.<SelectManyIterator>d__14`2.MoveNext()
       bij System.Linq.Buffer`1..ctor(IEnumerable`1 source)
       bij System.Linq.Enumerable.ToArray[TSource](IEnumerable`1 source)
       bij Rebus.Bus.Dispatcher.Dispatch[TMessage](TMessage message)
       bij Rebus.Bus.Worker.DispatchGeneric[T](T message)   bij Rebus.Bus.Worker.DoTry()
    Rebus.Bus.RebusBus WARN (Rebus 1 worker 1): Message RoodFluweel.Messaging.Models.Commands.SendPrintAtHomeTickets is forwarded to error queue
