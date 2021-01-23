    public Page1()
    {
        InitializeComponent();
        var objWP8PullDetector = new WP8PullDetector();
        objWP8PullDetector.Bind(objLongListSelector);
        //objWP8PullDetector.Unbind(); To unbind from compression detection
        objWP8PullDetector.Compression += objWP8PullDetector_Compression;
    }
    
    void objWP8PullDetector_Compression(object sender, CompressionEventArgs e)
    {
        //TODO: Your logic here
    }
