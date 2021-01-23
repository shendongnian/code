    public class MyCheckBox : CheckBox
    {
        private static readonly bool IsInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private HandPointer _capturedHandPointer;
        public MyCheckBox()
        {
            if (!IsInDesignMode)
            {
                Initialise();
            }
        }
        private void Initialise()
        {
            KinectRegion.AddHandPointerPressHandler(this, this.OnHandPointerPress);
            KinectRegion.AddHandPointerGotCaptureHandler(this, this.OnHandPointerCaptured);
            KinectRegion.AddHandPointerPressReleaseHandler(this, this.OnHandPointerPressRelease);
            KinectRegion.AddHandPointerLostCaptureHandler(this, this.OnHandPointerLostCapture);
            KinectRegion.AddHandPointerEnterHandler(this, this.OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(this, this.OnHandPointerLeave);
            KinectRegion.SetIsPressTarget(this, true);
        }
    }
    private void OnHandPointerLeave(object sender, HandPointerEventArgs e)
    {
        if (!KinectRegion.GetIsPrimaryHandPointerOver(this))
        {
            VisualStateManager.GoToState(this, "Normal", true);
        }
    }
    private void OnHandPointerEnter(object sender, HandPointerEventArgs e)
    {
        if (KinectRegion.GetIsPrimaryHandPointerOver(this))
        {
            VisualStateManager.GoToState(this, "MouseOver", true);
        }
    }
    private void OnHandPointerLostCapture(object sender, HandPointerEventArgs e)
    {
        if (_capturedHandPointer == e.HandPointer)
        {
            _capturedHandPointer = null;
            IsPressed = false;
            e.Handled = true;
        }
    }
    private void OnHandPointerCaptured(object sender, HandPointerEventArgs e)
    {
        if (_capturedHandPointer == null)
        {
            _capturedHandPointer = e.HandPointer;
            IsPressed = true;
            e.Handled = true;
        }
    }
    private void OnHandPointerPress(object sender, HandPointerEventArgs e)
    {
        if (_capturedHandPointer == null && e.HandPointer.IsPrimaryUser && e.HandPointer.IsPrimaryHandOfUser)
        {
            e.HandPointer.Capture(this);
            e.Handled = true;
        }
    }
    private void OnHandPointerPressRelease(object sender, HandPointerEventArgs e)
    {
        if (_capturedHandPointer == e.HandPointer)
        {
            if (e.HandPointer.GetIsOver(this))
            {
                OnClick();
                VisualStateManager.GoToState(this, "MouseOver", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", true);
            }
            e.Handled = true;
        }
    }
