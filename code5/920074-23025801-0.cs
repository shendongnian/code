	private MainViewModel MainViewModel;
	protected override async void OnNavigatedTo(NavigationEventArgs e)
	{
		MainViewModel = new MainViewModel();
		using (var iso = IsolatedStorageFile.GetUserStoreForApplication())
		{
			try
			{
				if (iso.FileExists("AppState.date"))
				{
					using (var stream = iso.OpenFile("AppState.dat", FileMode.Append, FileAccess.Write))
					{
						string text;
						using (var reader = new StreamReader(stream))
						{
							text = await reader.ReadToEndAsync();
						}
						var history = JsonConvert.DeserializeObject<List<History>>(text);
						MainViewModel.Items = history;
					}
				}
			}
			catch (IOException)
			{
				// TODO: log
			}
		}
	}
	protected override async void OnNavigatedFrom(NavigationEventArgs e)
	{
		using (var iso = IsolatedStorageFile.GetUserStoreForApplication())
		{
			try
			{
				using (var stream = iso.OpenFile("AppState.dat", FileMode.Create, FileAccess.Write))
				{
					Debug.WriteLine(stream.Length);
					using (var writer = new StreamWriter(stream))
					{
						await writer.WriteLineAsync(JsonConvert.SerializeObject(MainViewModel.Items));
					}
				}
			}
			catch (IOException)
			{
				// TODO: log
			}
		}
	}
