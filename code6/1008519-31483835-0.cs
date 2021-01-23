    public MainPage()
    {
        this.InitializeComponent();
        gestureRecognizer.GestureSettings = Windows.UI.Input.GestureSettings.Drag;
        gestureRecognizer.Dragging += gestureRecognizer_Dragging;
        GrdFoto.PointerPressed += GrdFoto_PointerPressed;
        GrdFoto.PointerMoved += GrdFoto_PointerMoved;
        GrdFoto.PointerReleased += GrdFoto_PointerReleased;
        GrdFoto.PointerCanceled += GrdFoto_PointerCanceled;
    }
        
    void GrdFoto_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        this.gestureRecognizer.ProcessDownEvent(e.GetCurrentPoint(this.GrdFoto));
        this.GrdFoto.CapturePointer(e.Pointer);
        e.Handled = true;
    }
    void GrdFoto_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        this.gestureRecognizer.ProcessMoveEvents(e.GetIntermediatePoints(this.GrdFoto));
    }
    void GrdFoto_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        this.gestureRecognizer.ProcessUpEvent(e.GetCurrentPoint(this.GrdFoto));   
        e.Handled = true;
    }
    void GrdFoto_PointerCanceled(object sender, PointerRoutedEventArgs e)
    {
        this.gestureRecognizer.CompleteGesture();
        e.Handled = true;
    }
    void gestureRecognizer_Dragging(GestureRecognizer sender, DraggingEventArgs args)
    {
        // Drag completed.
    }
