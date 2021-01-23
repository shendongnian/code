    bool timerRunning = false; // define it as a global variable
    
    // then in your timer process add this easy check
    public void RefreshPlotList(object source, ElapsedEventArgs e)
    {
        if(timerRunning) return; // return if it is busy
        timerRunning = true;  // set it to busy
    
        PlotComponent.RefreshPlot();
        Dispatcher.Invoke(() =>
        {
            if (!string.IsNullOrWhiteSpace(FilterTextBox.Text) &&
                (!Regex.IsMatch(FilterTextBox.Text, "[^0-9]")))
            {
                _filterPlotReference = Convert.ToInt32(FilterTextBox.Text);
            }
        });
        SetPlotList(_filterPlotReference);
        FocusPlotItem(_focusPlotReference);
    
        timerRunning = false;  // reset it for next time use
    }
