    class MyWindow : Window
    {
        protected override void OnSourceInitialized(EventArgs e)
        {
             base.OnSourceInitialized(e);
             var handle = new WindowInteropHelper(this).Handle;
             // -- or --
             var hwndSource = (HwndSource)PresentationSource.FromVisual(this);
             var handle = hwndSource.Handle;
        }
    }
