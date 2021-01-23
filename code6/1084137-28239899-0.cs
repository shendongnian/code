	async public Task Try(Action action, string errorMessage = null, string waitMessage = null)
	{
		try
		{
			if (waitMessage != null)
			{
				ShowLoading(waitMessage);
				await Task.Factory.StartNew(() => action());
			}
			else
				action();
		}
		catch (Exception e)
		{
			ShowError(errorMessage, e);
		}
		finally
		{
			HideLoading();
		}
	}
