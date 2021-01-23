    using Windows.Foundation;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    namespace ProofOfConcept.App.Controls
    {
        public class SignatureCaptureControl : Canvas
        {
            private WriteableBitmap _writeableBitmap;
            private Point _currentPoint;
            private Point _oldPoint;
            public SignatureCaptureControl()
            {
                _writeableBitmap = new WriteableBitmap(300, 130);
                PointerPressed += SignatureCaptureControl_PointerPressed;
                PointerMoved += SignatureCaptureControl_PointerMoved;
            }
            private void SignatureCaptureControl_PointerPressed(object sender, PointerRoutedEventArgs e)
            {
                _currentPoint = e.GetCurrentPoint(this).Position;
                _oldPoint = _currentPoint;
            }
            void SignatureCaptureControl_PointerMoved(object sender, PointerRoutedEventArgs e)
            {
                _currentPoint = e.GetCurrentPoint(this).Position;
                _writeableBitmap.DrawLine((int)_currentPoint.X, (int)_currentPoint.Y, (int)_oldPoint.X, (int)_oldPoint.Y, PenColor);
                this.InvalidateArrange();
                _oldPoint = _currentPoint;
            }
    
            public void ClearSignature()
            {
                _writeableBitmap.Clear();
            }
        }
    
    }
