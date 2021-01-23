    public partial class MainWindow
    {
        public Point position;
        
        public MainWindow
        {
            KinectRegion.AddHandPointerMoveHandler(this, OnHandPointerMove);
        }
        private void OnHandPointerMove(object sender, HandPointerEventArgs e)
        {
            position = e.HandPointer.GetPosition(myCanvas);
        }
    }
