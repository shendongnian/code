    RunOnUiThread((Action)delegate()
    {
        int length = internalModel.Series[i].Points.Count-1;
        float lastX = internalModel.Series[i].Points[0].X;
        for (int j = 0; j <= length; j++)
        {
            float x = ((float)targetImage.Width - 0) / (internalModel.Axes[0].Max - internalModel.Axes[0].Min) * (internalModel.Series[i].Points[j].X- lastX - internalModel.Axes[0].Min);
            float y = (0 - (float)targetImage.Height) / (internalModel.Axes[1].Max - internalModel.Axes[1].Min) * (internalModel.Series[i].Points[j].Y - internalModel.Axes[1].Min) + (float)targetImage.Height;
            tmpPoints.Add(new SharpDX.Vector2(x, y));
        }
    });
    ...
    public object RunOnUiThread(Delegate method)
    {
        return Dispatcher.Invoke(DispatcherPriority.Normal, method);
    }
