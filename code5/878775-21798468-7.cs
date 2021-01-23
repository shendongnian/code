    internal override void ChangeVisualState(bool useTransitions)
    {
        if (!base.IsEnabled)
        {
            VisualStateManager.GoToState(this, "Disabled", useTransitions);
        }
        else
        {
            if (this.IsReadOnly)
            {
                VisualStateManager.GoToState(this, "ReadOnly", useTransitions);
            }
            else
            {
                if (base.IsMouseOver)
                {
                    VisualStateManager.GoToState(this, "MouseOver", useTransitions);
                }
                else
                {
                    VisualStateManager.GoToState(this, "Normal", useTransitions);
                }
            }
        }
        if (base.IsKeyboardFocused)
        {
            VisualStateManager.GoToState(this, "Focused", useTransitions);
        }
        else
        {
            VisualStateManager.GoToState(this, "Unfocused", useTransitions);
        }
        base.ChangeVisualState(useTransitions);
    }
