    public TakeTourPage()
    {
        InitializeComponent();
        GestureListener gestureListener = GestureService.GetGestureListener(ContentPanel);
        gestureListener.DragCompleted += gestureListener_DragCompleted;
    }
    void gestureListener_DragCompleted(object sender, DragCompletedGestureEventArgs e)
    {
        
        // User flicked towards left
        if (e.HorizontalVelocity < 0)
        {
        }
        // User flicked towards right
        if (e.HorizontalVelocity > 0)
        {
        }
     }
