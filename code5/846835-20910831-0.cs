    protected override void OnParentChanged(EventArgs e)
    {
        base.OnParentChanged(e);
        if (this.Parent != null)
        {
            this.Parent.SizeChanged += OnFormSizeChanged; // this.ParentForm.SizeChanged += ...
        }
    }
    void OnFormSizeChanged(object sender, EventArgs e)
    {
        // ...
    }
