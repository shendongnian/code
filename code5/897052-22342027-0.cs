	private SerialDisposable _subscription = new SerialDisposable();
	
	private void button1_Click(object sender, EventArgs e)
	{
		string st = "hello my name is miroslav glamuzina";
		string[] arr = st.Split(' ');
		
		_subscription.Disposable = 
			Observable
				.Interval(TimeSpan.FromMilliseconds(50.0))
				.Select(i => arr[(int)i])
				.Take(arr.Length)
				.ObserveOn(this)
				.Subscribe(word =>
				{
					label1.Text = word;
				});
	}
