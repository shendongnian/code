    public Image CapturedImage { get; private set; }
    public ProgressEventArgs(Image img)
    {
            CapturedImage = img;
    }
