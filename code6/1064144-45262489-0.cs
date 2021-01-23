	public async void RunAsync()
    {
        UserCredential credential;
	    var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read);
	    CancellationTokenSource cts = new CancellationTokenSource();
	    cts.CancelAfter(TimeSpan.FromSeconds(20));
	    CancellationToken ct = cts.Token;
	    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
		GoogleClientSecrets.Load(stream).Secrets,
		new[] { YouTubeService.Scope.YoutubeUpload },
		"user",
		ct
	    );
	    if (ct.IsCancellationRequested) return;
        // do more stuff when came back authorized.
    }
