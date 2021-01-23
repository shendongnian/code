    /// <summary>
    /// Event handler to care Window loaded
    /// Construct KinectMicArray and draw contents
    /// </summary>
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        kinectMic = new KinectMicArray();
        kinectMic.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(kinectMic_PropertyChanged);
        DrawContents();
    }
    /// <summary>
    /// Event handler to care KinectMicArray property changed
    /// Showing angles as number for debug
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void kinectMic_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        KinectMicArray ka = sender as KinectMicArray;
        this.myLabel.Content = string.Format("Beam = {0:F}; Source = {1:F};  ", ka.BeamAngleProperty, ka.SourceAngleProperty); 
    }
