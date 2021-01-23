    public ModelWorkspace()
    {
        InitializeComponent();
        innerLayer = new Canvas();
        // Add "innerLayer" to the canvas defined as the child of this ModelWorkspace.
        var childCanvas = Child as Canvas;
        if (childCanvas != null)
        {
            childCanvas.Children.Add(innerLayer);
        }
        // else the child is not a canvas.
    }
