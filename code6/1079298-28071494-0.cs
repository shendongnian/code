     private void ApplyChanges()
     {
        graphicsOptions.Height = graphics.PreferredBackBufferHeight;
        graphicsOptions.Width = graphics.PreferredBackBufferWidth;
        graphicsOptions.Fullscreen = graphics.IsFullScreen;
        graphicsOptions.AntiAliasing = graphics.PreferMultiSampling;
        graphicsOptions.ClickResCount = clickCountResolution;
        dataStream = File.Open(SavegamePath, FileMode.Create); // You can use FileMode.Truncate as well.
        XmlSerializer serializer = new XmlSerializer(typeof(GraphicsOptions));
        serializer.Serialize(dataStream, graphicsOptions);
        dataStream.Close();
      }
