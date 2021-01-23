     ToolStripContainer  = toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
     // StatusBar
     // 
     ToolStripStatusLabel StatusBar = new System.Windows.Forms.ToolStripStatusLabel();
     StatusBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
     StatusBar.ForeColor = System.Drawing.Color.Blue;
     StatusBar.LinkColor = System.Drawing.Color.Navy;
     StatusBar.Name = "StatusBar";
     StatusBar.Size = new System.Drawing.Size(732, 20);
     StatusBar.Spring = true;
     StatusBar.Text = "Status Messages Go Here";
     StatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
     // 
     // ProgressBar
     // 
     ToolStripProgressBar ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
     ProgressBar.ForeColor = System.Drawing.Color.Yellow;
     ProgressBar.Name = "ProgressBar";
     ProgressBar.Size = new System.Drawing.Size(150, 19);
     // 
     // StatusStrip
     // 
     StatusStrip StatusStrip = new System.Windows.Forms.StatusStrip();
     StatusStrip.Dock = System.Windows.Forms.DockStyle.None;
     StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
     StatusBar, this.ProgressBar});
     StatusStrip.Location = new System.Drawing.Point(0, 0);
     StatusStrip.Name = "StatusStrip";
     StatusStrip.Size = new System.Drawing.Size(899, 25);
     StatusStrip.TabIndex = 0;
     toolStripContainer1.BottomToolStripPanel.Controls.Add(this.StatusStrip);
