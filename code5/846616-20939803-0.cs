	public partial class MainWindow : Window
	{
		public static void StopPlayback()
		{
			if (waveOutDevice != null && waveOutDevice.PlaybackState == PlaybackState.Playing)
				waveOutDevice.Stop();
		}
	}
