    foreach (Control child in list)
        DoSomethingWithThe(control);
    void DoSomethingWithThe(Control control)
    {
        Button button = control as Button;
        if (button != null)
        {
            button.Click += Button_Click;
            return;
        }
        Label label = control as Label;
        if (label != null)
        {
            label.MouseOver += Label_MouseOver;
            return;
        }
        //... etc.
    }
