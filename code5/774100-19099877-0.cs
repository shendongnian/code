    private void ZoomToggle(bool Enabled)
    {
    	// Enable range selection and zooming end user interface
    	this.cwSubplot.ChartAreas(0).CursorX.IsUserEnabled = Enabled;
    	this.cwSubplot.ChartAreas(0).CursorX.IsUserSelectionEnabled = Enabled;
    	this.cwSubplot.ChartAreas(0).CursorX.Interval = 0;
    	this.cwSubplot.ChartAreas(0).AxisX.ScaleView.Zoomable = Enabled;
    	this.cwSubplot.ChartAreas(0).AxisX.ScrollBar.IsPositionedInside = true;
    	this.cwSubplot.ChartAreas(0).AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
    	this.cwSubplot.ChartAreas(0).AxisX.ScaleView.SmallScrollMinSize = 0;
    
    	this.cwSubplot.ChartAreas(0).CursorY.IsUserEnabled = Enabled;
    	this.cwSubplot.ChartAreas(0).CursorY.IsUserSelectionEnabled = Enabled;
    	this.cwSubplot.ChartAreas(0).CursorY.Interval = 0;
    	this.cwSubplot.ChartAreas(0).AxisY.ScaleView.Zoomable = Enabled;
    	this.cwSubplot.ChartAreas(0).AxisY.ScrollBar.IsPositionedInside = true;
    	this.cwSubplot.ChartAreas(0).AxisY.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
    	this.cwSubplot.ChartAreas(0).AxisY.ScaleView.SmallScrollMinSize = 0;
    	if (Enabled == false) {
    		//Remove the cursor lines
    		this.cwSubplot.ChartAreas(0).CursorX.SetCursorPosition(double.NaN);
    		this.cwSubplot.ChartAreas(0).CursorY.SetCursorPosition(double.NaN);
    	}
    }
