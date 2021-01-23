		private class NW : NativeWindow {
			public NW(IntPtr handle) {
				AssignHandle(handle);
			}
			const int WM_PAINT = 0xF;
			protected override void WndProc(ref Message m) {
				// can ignore all messages too
				if (m.Msg == WM_PAINT) {
					return;
				}
				base.WndProc(ref m);
			}
		}
		[STAThread]
		static void Main() {
			MenuStrip menu = new MenuStrip();
			NW nw = null; // declared outside to prevent garbage collection
			ToolStripMenuItem item1 = new ToolStripMenuItem("Item1");
			ToolStripMenuItem subItem1 = new ToolStripMenuItem("Sub Item1");
			subItem1.DropDown.DropShadowEnabled = false;
			subItem1.DropDown.HandleCreated += delegate {
				nw = new NW(subItem1.DropDown.Handle);
			};
			ToolStripMenuItem miMakeVisible = new ToolStripMenuItem("Make Visible");
			miMakeVisible.Click += delegate {
				if (nw != null) {
					nw.ReleaseHandle();
					nw = null;
				}
			};
			ToolStripMenuItem subItem2 = new ToolStripMenuItem("Sub Item2");
			item1.DropDownItems.Add(subItem1);
			item1.DropDownItems.Add(miMakeVisible);
			subItem1.DropDownItems.Add(subItem2);
			menu.Items.Add(item1);
			Form f = new Form();
			f.Controls.Add(menu);
			f.MainMenuStrip = menu;
			Application.Run(f);
		}
