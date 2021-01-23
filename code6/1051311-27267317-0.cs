	public class BarcodeScannerMessageFilter : IMessageFilter
	{
		public event EventHandler<BarcodeScannerReadyEventArgs> BarcodeScannerReady;
		private bool barcodeStarted = false;
		private StringBuilder barcodeBuilder = new StringBuilder();
		public BarcodeScannerMessageFilter()
		{
			Application.AddMessageFilter(this);
		}
		#region IMessageFilter Members
		private const int WM_KEYDOWN = 0x100;
		private const int WM_MSG = 0x102;
		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == WM_KEYDOWN) // Use KeyDown to look for prefix and surfix
			{
				Keys keyCode = (Keys)(int)m.WParam & Keys.KeyCode;
				if (!barcodeStarted) // Prevent F13 Capture until previous is ended
				{
					// Check for start capture key (F13)
					if (keyCode == Keys.F13)
					{
						barcodeStarted = true;
						return true;
					}
				}
				else
				{
					// Check for end capture key (Enter)
					if (keyCode == Keys.Enter)
					{
						// Raise barcode capture event with barcode
						RaiseBarcodeReadyEventAsync(barcodeBuilder.ToString());
						// End sequence
						barcodeBuilder.Clear();
						barcodeStarted = false;
						return true;
					}
				}
			}
			else if (m.Msg == WM_MSG) // Catch all char messages
			{
				char c = (char)m.WParam;
				// Else just append char to barcodeBuilder to generate barcode
				barcodeBuilder.Append(c);
				return true;
			}
			return false;
		}
		#endregion
		private void RaiseBarcodeReadyEventAsync(string barcode)
		{
			Task.Factory.StartNew(() =>
			{
				try
				{
					// Generate barcode
					Console.WriteLine("F13 activated barcode [" + barcode + "]");
					if (BarcodeScannerReady != null)
					{
						BarcodeScannerReady(this, new BarcodeScannerReadyEventArgs(barcode));
					}
				}
				catch (Exception ex)
				{
					// Do some error logging if needed
					Console.WriteLine(ex);
				}
			});
		}
	}
	public class BarcodeScannerReadyEventArgs : EventArgs
	{
		public string Barcode { get; private set; }
		public BarcodeScannerReadyEventArgs(string barcode)
		{
			this.Barcode = barcode;
		}
	}
    
