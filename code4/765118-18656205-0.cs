    Form activeForm = Form.ActiveForm;
    Control activeControl = activeForm.ActiveControl;
    while (activeControl.HasChildren)
    {
        activeControl = activeControl
            .Controls
            .Cast<Control>()
            .FirstOrDefault(c => c.Focused);
    }
