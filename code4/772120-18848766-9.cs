    private void DisplayImage(Image result)
    {
        if (this.InvokeRequired)
        {
            Invoke(new Action<Image>(DisplayImage), result);
            return;
        }
        _picLoadingJobCard.Visible = false;
        _picJobCard.Image = result;
    }
