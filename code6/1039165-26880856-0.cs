    private void InitializeComponent()
    {
    	this.plot1 = new OxyPlot.WindowsForms.PlotView();
    	this.SuspendLayout();
    	// 
    	// plot1
    	// 
    	this.plot1.Dock = System.Windows.Forms.DockStyle.Bottom;
    	this.plot1.Location = new System.Drawing.Point(0, 0);
    	this.plot1.Name = "plot1";
    	this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
    	this.plot1.Size = new System.Drawing.Size(500,500);
    	this.plot1.TabIndex = 0;
    	this.plot1.Text = "plot1";
    	this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
    	this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
    	this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
    	this.Controls.Add(this.plot1);
    	
    	//
    	// other comtrols
    	//
    	
    }
    private OxyPlot.WindowsForms.PlotView plot1;
