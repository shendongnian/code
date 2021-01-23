			Application.EnableVisualStyles();
			Form f = new Form();
			ProgressBar pb = new ProgressBar() { Minimum = 0, Maximum = 10, Dock = DockStyle.Top };
			Button btn = new Button { Text = "Button", Dock = DockStyle.Top };
			f.Controls.Add(pb);
			f.Controls.Add(btn);
			btn.Click += delegate {
				Thread t = new Thread(() => {
					for (int i = 0; i <= 10; i++) {
						pb.BeginInvoke((Action) delegate {
							pb.Value = i;
						});
						Thread.Sleep(1000);
					}
				});
				t.IsBackground = true;
				t.Start();
				Thread t2 = new Thread(() => {
					Thread.Sleep(3000);
					f.BeginInvoke((Action) delegate {
						Form f2 = new Form();
						var r = f2.ShowDialog(f);
					});
				});
				t2.IsBackground = true;
				t2.Start();
			};
			Application.Run(f);
