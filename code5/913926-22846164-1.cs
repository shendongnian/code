        var button = new KinectTileButton
        {
             Label = System.IO.Path.GetFileNameWithoutExtension(file),
             Background = new ImageBrush(bi),
             Tag = file
        };
        var selectionDisplay = new SelectionDisplay(button.Label as string, button.Tag as string);
