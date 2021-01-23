		NumericUpDown nud = new NumericUpDown();
		nud.Font = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular);
		bool isSet = false;
		nud.VisibleChanged += delegate {
			// NUD children consist of two child windows:
			// 1) TextBox
			// 2) UpDownBase - which uses user draw
			if (!isSet) {
				var list = GetChildWindows(nud.Handle);
				foreach (var hwnd in list) {
					var udb = Control.FromHandle(hwnd);
					if (udb != null && !(udb is TextBox)) {
						// prevent flicker
						typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, udb, new object[] { true });
						udb.Paint += (sender,e) => {
							var g = e.Graphics;
							int h = udb.Height;
							int w = udb.Width;
							// cover up the default Up/Down arrows:
							g.FillRectangle(SystemBrushes.Control, 3, 3, w - 6, h/2 - 6);
							g.FillRectangle(SystemBrushes.Control, 3, h/2 + 3, w - 6, h/2 - 6);
						};
						isSet = true;
					}
				}
			}
		};
