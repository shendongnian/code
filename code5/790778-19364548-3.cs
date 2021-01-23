    private void BeginCloseAnimation()
    {
        SlideDoubleAnimation.From = System.Windows.SystemParameters.WorkArea.Height - 
            this.Height - 2;
        SlideDoubleAnimation.To = System.Windows.SystemParameters.WorkArea.Height;        
        SlideStoryboard.Begin();
        close = true;
    }
    private void SlideDoubleAnimation_Completed(object sender, EventArgs e)
    {
        if (close) Close();
    }
