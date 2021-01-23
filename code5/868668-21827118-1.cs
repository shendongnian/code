    public Task CreateAnimationFileAsync(IEnumerable<Bitmap> frames)
    {
        var frameProcessor = new TransformBlock<Bitmap, Bitmap>(
            frame => ProcessFrame(frame),
            new ExecutionDataflowBlockOptions
            { MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded });
        var animationWriter = new ActionBlock<Bitmap>(frame => WriteFrame(frame));
        frameProcessor.LinkTo(
            animationWriter,
            new DataflowLinkOptions { PropagateCompletion = true });
        foreach (var frame in frames)
        {
            frameProcessor.Post(frame);
        }
        frameProcessor.Complete();
        return animationWriter.Completion;
    }
    private Bitmap ProcessFrame(Bitmap frame)
    {
        …
    }
    private async Task WriteFrame(Bitmap frame)
    {
        …
    }
