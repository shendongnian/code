    for (int i = 0; i < canvases.Count; i++)
    {
        canvases[i] = new Canvas();
        canvases[i].Width = sheetWidth;
        canvases[i].Height = sheetHeight;
        canvases[i].Background = Brushes.White;
        canvases[i].RenderTransform = new ScaleTransform();
        canvases[i].MouseWheel += (sender, e) =>
        {
            double ScaleRate = 1.00000001; // really ??
            var canvas = (Canvas)sender;
            var scaletransform = (ScaleTransform)canvas.RenderTransform;
            if (e.Delta > 0)
            {
                scaletransform.ScaleX *= ScaleRate;
                scaletransform.ScaleY *= ScaleRate;
            }
            else
            {
                scaletransform.ScaleX /= ScaleRate;
                scaletransform.ScaleY /= ScaleRate;
            }
       };
       stackPanel.Children.Add(canvases[i]);
 }
