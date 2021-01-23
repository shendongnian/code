	class StartProcessEx : Process
    {
        internal void CloseProcess()
		{
			if (!this.HasExited)
			{
				this.CloseMainWindow();
			}
		}
    }
