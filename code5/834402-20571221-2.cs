    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        //Apply bindings and events
        ContentPresenter leftContent = GetTemplateChild("LeftContent") as ContentPresenter;
        leftContent.SetBinding(ContentPresenter.ContentProperty, new Binding("Left") { Source = this });
        ContentPresenter rightContent = GetTemplateChild("RightContent") as ContentPresenter;
        rightContent.SetBinding(ContentPresenter.ContentProperty, new Binding("Right") { Source = this });
    }
