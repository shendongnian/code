    public override void ViewDidDisappear(bool animated)
    {
        ProcessButton.TouchUpInside -= DoSomething;
        base.ViewDidDisappear (animated);
    }
