    public static int InstanceCounter = 0;
    private bool disposed;
    public CustomControl()
    {
        InstanceCounter++;
        InitializeComponent();
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing && !this.disposed)
        {
            InstanceCounter--;
            this.disposed = true;
        }
    }
