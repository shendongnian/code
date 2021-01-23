    private static readonly ActionBlock<ETMWNet.ETGazeDataType> _queue = new ActionBlock<ETMWNet.ETGazeDataType>(
      async pGazeData =>
      {
        StorageFolder ETfolder = ApplicationData.Current.LocalFolder;
        StorageFile file = await ETfolder.CreateFileAsync("Log.ETDGazeDataEvent.txt", CreationCollisionOption.OpenIfExists);
        String ETAnswer = pGazeData.FrameNum + " Time: " + pGazeData.TimeStamp + " X: " + pGazeData.Left.GazePointPixels.x + " Y: " + pGazeData.Left.GazePointPixels.y + " \r\n";
        await Windows.Storage.FileIO.AppendTextAsync(file, ETAnswer);
      });
    static void ETDGazeDataEvent(ETMWNet.ETGazeDataType pGazeData)
    {
      _queue.Post(pGazeData);
    }
