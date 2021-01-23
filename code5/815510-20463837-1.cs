    [TestMethod]
    async public Task TestMethod1()
    {
		var taskSource = new TaskCompletionSource<object>();
		await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
			CoreDispatcherPriority.Normal, async () =>
		{
			try
			{
				var t = new ObservableCollection<CommentEvent>();
				t.Add(new CommentEvent(Colors.LightPink) { Label = "Bad", 
					  EventTime = TimeCode.FromTicks(DateTime.Now.Ticks,
					  TimeCode.SmpteFrameRate.Smpte2997Drop) });
				t.Add(new CommentEvent(Colors.DarkSeaGreen) { Label = "Good",
					   EventTime = TimeCode.FromTicks(DateTime.Now.Ticks,
					   TimeCode.SmpteFrameRate.Smpte2997Drop) });
				t.Add(new CommentEvent(Colors.LightPink) { Label = "Bad",
					   EventTime = TimeCode.FromTicks(DateTime.Now.Ticks,
					   TimeCode.SmpteFrameRate.Smpte2997Drop) });
				t.Add(new CommentEvent(Colors.DarkSeaGreen) { Label = "Good",
					   EventTime = TimeCode.FromTicks(DateTime.Now.Ticks,
					   TimeCode.SmpteFrameRate.Smpte2997Drop) });
				var s = await PreludeXMP.Get(t);
				Assert.IsNotNull(s);
				System.Diagnostics.Debug.WriteLine(s);
				askSource.SetResult(null);
			}
			catch (Exception e)
			{
				taskSource.SetException(e);
			}
		}
		await taskSource.Task;
    }
