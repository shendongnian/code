    namespace WpfApplication1
	{
		public class EscapeWindow : Window
		{
			public EscapeWindow()
				: base()
			{
				this.KeyDown += new KeyEventHandler(HandleEsc);
			}
			private void HandleEsc(object sender, KeyEventArgs e)
			{
				if (e.Key == Key.Escape) { this.Close(); }
			}
		}
	}
