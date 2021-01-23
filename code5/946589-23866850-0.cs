    private bool mShowAllowed;
    protected override void SetVisibleCore(bool value)
    {
        if (!mShowAllowed) value = false;
        {
            base.SetVisibleCore(value); 
        }
    }
