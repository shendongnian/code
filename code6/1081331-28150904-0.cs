    public void UpdateImage(BufferedImage img) 
    { 
        Action updateImage = () => { this.Image.Source = img };
        Dispatcher.BeginInvoke(updateImage);
    }
