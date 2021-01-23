    private void ApplyChanges()
    {
        graphicsOptions.Height = graphics.PreferredBackBufferHeight;
        graphicsOptions.Width = graphics.PreferredBackBufferWidth;
        graphicsOptions.Fullscreen = graphics.IsFullScreen;
        graphicsOptions.AntiAliasing = graphics.PreferMultiSampling;
        graphicsOptions.ClickResCount = clickCountResolution;
        using(dataStream = File.Open(SavegamePath, FileMode.Create))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GraphicsOptions));
            serializer.Serialize(dataStream, graphicsOptions);
        }
    }
