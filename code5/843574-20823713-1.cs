    private void seekBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
    	double MousePosition = e.GetPosition(seekBar).X;
        this.seekBar.Value = SetProgressBarValue(MousePosition);
    }
    
    private double SetProgressBarValue(double MousePosition)
    {
    	double ratio = MousePosition/seekBar.ActualWidth;
    	double ProgressBarValue = ratio*seekBar.Maximum;
    	return ProgressBarValue;
    }
