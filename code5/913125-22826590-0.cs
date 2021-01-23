    //Marking the class sealed so we don't need to deal with 
    //    the "protected virtual void Dispose(bool disposing)" pattern.
    sealed class IntervalLabel : IDisposable
    {
        private Label intervalLabel;
    
        public IntervalLabel(Canvas mainCanvas)
        {
            intervalLabel = new Label();
            mainCanvas.Children.Add(intervalLabel);
            intervalLabel.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(IntervalLabel_MouseDown);
        }
    
        private void IntervalLabel_MouseDown(object sender, MouseEventArgs e)
        {
            //....
        }
    
        public void Dispose()
        {
            intervalLabel.MouseLeftButtonDown -= new         System.Windows.Input.MouseButtonEventHandler(IntervalLabel_MouseDown);
            commonParameters.mainCanvas.Children.Remove(intervalLabel);
        }
    }
