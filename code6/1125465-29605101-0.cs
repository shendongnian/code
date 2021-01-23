    //inside the constructor
    {
        DependencyPropertyDescriptor
            .FromProperty(RenderTransformProperty)
            .AddValueChanged(this, new EventHandler(RenderTransformPropertyChanged));
    }
    private void RenderTransformPropertyChanged(object sender, EventArgs e)
    {
        //this.RenderTransform.Changed += ...
    }
