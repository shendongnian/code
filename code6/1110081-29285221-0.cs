		public class ContextMenuStrip2 : ContextMenuStrip {
			// could do this on OnHandleCreated, but the scroll buttons might not
			// be visible if items are added to the context menu later on
			protected override void OnVisibleChanged(EventArgs e) {
 				base.OnVisibleChanged(e);
				this.BeginInvoke((Action) delegate {
					var list = GetChildWindows(this.Handle);
					int k = 0;
					foreach (var i in list) {
						var c = (Label) Control.FromHandle(i);
						if (!c.AutoSize) {
							String glyph = (k == 0 ? "t" : "u");
							using (Font f = new System.Drawing.Font("Marlett", 20f)) {
								Size s = TextRenderer.MeasureText("t", f);
								c.Image = new Bitmap(s.Width, s.Height);
								using (Graphics g = Graphics.FromImage(c.Image)) {
									using (Brush b = new SolidBrush(this.ForeColor))
										g.DrawString(glyph, f, b, 0, 0);
								}
								c.AutoSize = true;
							}
							k++;
						}
					}
				});
			}
			private static List<IntPtr> GetChildWindows(IntPtr parent) {
				List<IntPtr> result = new List<IntPtr>();
				GCHandle listHandle = GCHandle.Alloc(result);
				try {
					EnumChildWindows(parent, enumProc, GCHandle.ToIntPtr(listHandle));
				} finally {
					if (listHandle.IsAllocated)
						listHandle.Free();
				}
				return result;
			}
			private delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);
			private static EnumChildProc enumProc = new EnumChildProc(CallChildEnumProc);
			private static bool CallChildEnumProc(IntPtr hWnd, IntPtr lParam) {
				GCHandle gch = GCHandle.FromIntPtr(lParam);
				List<IntPtr> list = gch.Target as List<IntPtr>;
				if (list == null)
					throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
				list.Add(hWnd);
				return true;
			}
			[DllImport("user32.dll")]
			private static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);
		}
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			var cms = new ContextMenuStrip2();
			for (int i = 0; i < 20; i++)
				cms.Items.Add(new ToolStripMenuItem("Item " + i));
			cms.MaximumSize = new Size(200, 400);
			Form f = new Form();
			f.ContextMenuStrip = cms;
			Application.Run(f);
		}
