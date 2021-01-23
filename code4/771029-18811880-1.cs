    int previousProgress = progressBar.Value;
    progressBar.Value = ...
    if (progressBar.Value != previousProgress)
    {
      progressBar.DrawToBitmap(progressBarBitmap, bounds);
      progressBarImageList.Images[index] = progressBarBitmap;
    }
