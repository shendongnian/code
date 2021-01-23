		public NW(IntPtr hwnd) {
			AssignHandle(hwnd);
		}
		const int WM_NCHITTEST = 0x84;
		protected override void WndProc(ref Message m) {
			if (m.Msg == WM_NCHITTEST)
				return;
			base.WndProc(ref m);
		}
	}
