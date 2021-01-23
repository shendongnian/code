    protected override void CreateChildControls()
    {
        base.CreateChildControls();
        LiteralControl message = new LiteralControl();
        message.Text = CustomTextProp;
        Controls.Add(message);
    }
