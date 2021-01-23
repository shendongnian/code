       [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            var sampleForm = new Form() { AutoScroll = true };
    
    		var panel = new MyPanel() { AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, BackColor = Color.LightYellow };
    
    		for (int i = 0; i < 6; i++) {
    			for (int j = 0; j < 3; j++) {
    				Button b = new Button { Text = "Button" + panel.Controls.Count, AutoSize = true };
    				b.Click += delegate {
    					MessageBox.Show("Preferred Size: " + panel.PreferredSize);
    				};
    				panel.Controls.Add(b, j, i);
    			}
    		}
    
    		sampleForm.Controls.Add(panel);
            Application.Run(sampleForm);
        }
    
    	private class MyPanel : TableLayoutPanel {
    		public override Size MinimumSize {
    			get {
    				return PreferredSize;
    			}
    			set {
    				
    			}
    		}
    
    		public override Size GetPreferredSize(Size proposedSize) {
    			Size s = new Size();
    			int[] harr = new int[100];//this.RowCount];
    			int[] warr = new int[100];//this.ColumnCount];
    			foreach (Control c in this.Controls) {
    				var cell = this.GetPositionFromControl(c);
    				var ps = c.PreferredSize;
    				Padding m = c.Margin;
    				int w = ps.Width + m.Horizontal;
    				int h = ps.Height + m.Vertical;
    				if (w > warr[cell.Column])
    					warr[cell.Column] = w;
    				if (h > harr[cell.Row])
    					harr[cell.Row] = h;
    			}
    
    			foreach (int w in warr)
    				s.Width += w;
    			foreach (int h in harr)
    				s.Height += h;
    
    			return s;
    		}
    	}
