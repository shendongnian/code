	void Form1_Load(object sender, EventArgs e)
	{
		var task = DoNavigationAsync();
		task.ContinueWith((t) =>
		{
			MessageBox.Show("Navigation done!");
		});
	}
	struct Void {}; // use an empty struct as parameter to generic TaskCompletionSource
	async Task DoNavigationAsync()
	{
		Void v;
		TaskCompletionSource<Void> tcs = null; 
		WebBrowserDocumentCompletedEventHandler documentComplete = null;
		
		documentComplete = new WebBrowserDocumentCompletedEventHandler((s, e) =>
		{
			// more of DocumentCompleted can possibly be fired due to dynamic navigation inside the web page, we don't want them!
			this.WB.DocumentCompleted -= documentComplete; 				
			tcs.SetResult(v); // continue from where awaited
		});
		// navigate to www.bing.com
		tcs = new TaskCompletionSource<Void>();
		this.WB.DocumentCompleted += documentComplete;
		this.WB.Navigate("http://www.bing.com");
		await tcs.Task;
		// do whatever you want with this instance of WB.Document
		MessageBox.Show(this.WB.Document.Url.ToString());
		// navigate to www.google.com
		tcs = new TaskCompletionSource<Void>();
		this.WB.DocumentCompleted += documentComplete;
		this.WB.Navigate("http://www.google.com");
		await tcs.Task;
		// do whatever you want with this instance of WB.Document
		MessageBox.Show(this.WB.Document.Url.ToString());
		// navigate to www.yahoo.com
		tcs = new TaskCompletionSource<Void>();
		this.WB.DocumentCompleted += documentComplete;
		this.WB.Navigate("http://www.yahoo.com");
		await tcs.Task;
		// do whatever you want with this instance of WB.Document
		MessageBox.Show(this.WB.Document.Url.ToString());
		return;
	}
