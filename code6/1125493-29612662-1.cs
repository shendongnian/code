	public static class FormExt
	{
		public static async Task<DialogResult> ShowDialogAsync(
            Form @this, CancellationToken token = default(CancellationToken))
		{
			await Task.Yield();
			using (token.Register(() => @this.Close(), useSynchronizationContext: true))
			{
				return @this.ShowDialog();
			}
		}
	}
