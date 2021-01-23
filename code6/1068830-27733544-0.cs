    private void animationTimer_Tick(object sender, EventArgs e)
    {
        // if just starting, move to start location and make visible
        if (!photosPanel.Visible)
        {
            photosPanel.Left = _startLeft;
            photosPanel.Visible = true;
        }
        // incrementally move
        photosPanel.Left += _stepSize;
        // make sure we didn't over shoot
        if (photosPanel.Left > _endLeft) photosPanel.Left = _endLeft;
        // have we arrived?
        if (photosPanel.Left == _endLeft)
        {
            animationTimer.Enabled = false;
        }            
    }
