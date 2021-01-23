			public YourApp()
			{
				InitializeComponent();
				foreach (Control objCtrl in this.Controls) // get all the controls in the form
				{
					if (objCtrl is Panel) // get the Panel
					{
						objCtrl.MouseEnter += new EventHandler(panel_MouseEnter); // do something to the panel on MouseEnter
						objCtrl.MouseLeave += new EventHandler(panel_MouseLeave);
						foreach (Control ctl in objCtrl.Controls) // get all the controls inside the Panel
						{
							if (ctl is Label) // get the label inside the panel
							{
								ctl.MouseEnter += new System.EventHandler(label_MouseEnter);
								ctl.MouseLeave += new EventHandler(label_MouseLeave);
								ctl.Click += new EventHandler(label_Click);
							}
							if (ctl is PictureBox) // get the pictureBox inside the panel
							{
								ctl.MouseEnter += new EventHandler(label_MouseEnter);
							}
						}
					}
				}
			}
