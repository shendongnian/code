    var query = source.Window(TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(250));
	query.Deploy("windowQuery");
	var innerSink = applicationStatus.DefineObserver(() => Observer.Create<int>(c => /*output here*/));
	innerSink.Deploy("innerSink");
	var sink = applicationStatus.DefineObserver(() => Observer.Create<IObservable<EventPattern<MyEventArg>>>(e => e.Count().AsQbservable().Bind(innerSink).Run().Void()));
	sink.Deploy("mySink");
	ProcessBinding = query.Bind(sink).Run("processBindingName");
