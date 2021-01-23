    this.PointerEntered += (s, e) =>
    {
        if (e.Pointer.PointerDeviceType == PointerDeviceType.Mouse)
        {
            this.isUsingMouse = true;
            this.UpdateVisualState(true);
        }
        else
        {
            this.isUsingMouse = false;
            this.UpdateVisualState(true);
        }
    };
