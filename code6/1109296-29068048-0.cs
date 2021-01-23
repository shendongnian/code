        public static IObservable<string> Receive(NetMQContext ctx)
        {
			return Observable
				.Create<string>(o =>
					Observable.Using<string, SubscriberSocket>(() =>
					{
						var sub = ctx.CreateSubscriberSocket();
						sub.Connect("inproc://test");
						sub.Subscribe("");
						return sub;
					}, sub =>
					Observable
						.FromEventPattern<EventHandler<NetMQSocketEventArgs>, NetMQSocketEventArgs>(
							h => sub.ReceiveReady += h,
							h => sub.ReceiveReady -= h)
						.Select(x => sub.ReceiveString()))
				.Subscribe(o));
        }
