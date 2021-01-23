		NumericUpDown nud = new NumericUpDown();
		nud.Font = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular);
		bool isSet = false;
		NW nw = null;
		nud.Enabled = false;
		nud.VisibleChanged += delegate {
			// NUD children consist of two child windows:
			// 1) TextBox
			// 2) UpDownBase - which uses user draw
			if (!isSet) {
				foreach (Control c in nud.Controls) {
					if (!(c is TextBox)) {
						// prevent flicker
						typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, c, new object[] { true });
						c.Paint += (sender,e) => {
							var g = e.Graphics;
							int h = c.Height;
							int w = c.Width;
							// cover up the default Up/Down arrows:
							//g.FillRectangle(SystemBrushes.Control, 3, 3, w - 6, h/2 - 6);
							//g.FillRectangle(SystemBrushes.Control, 3, h/2 + 3, w - 6, h/2 - 6);
							// or hide the entire control
							if (nud.Enabled)
								g.Clear(nud.BackColor);
							else
								g.Clear(SystemColors.Control);
						};
						nw = new NW(c.Handle);
						isSet = true;
					}
				}
			}
		};
