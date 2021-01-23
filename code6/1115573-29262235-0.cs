			panel.Click += delegate {
				var l = Cursor.Position;
				l = panel.PointToClient(l);
				var c = panel.GetChildAtPoint(l);
				if (c == null) {
					// good
				}
				else {
					// ignore (disabled control)
				}
			};
