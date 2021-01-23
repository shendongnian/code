    Color pixelColor;
    using (var AlertImage = new Bitmap(Properties.Settings.Default.AlertFile))
    {
    	pixelColor = AlertImage.GetPixel(50, 50);
    }
    
    File.Delete(Properties.Settings.Default.AlertFile);
    
    if (pixelColor == Color.FromArgb(255, 237, 28, 36))
    {
    	AlertMessage.Text = @"It was Red :)";
    }
    else
    {
    	AlertMessage.Text = @"It was not Red :(";
    }
