    private void SomeNewMethod(IRootViewModel newValue)
    {
        // Create a child WpfViewWindow.  This method is part of my
        // framework that uses ResourceDictionary entries, imported by MEF
        // to locate the View class corresponding to the ViewModel parameter's
        // class.
        WpfViewWindow modelessWindow = CreateWpfViewWindow(newValue);
        if (null != modelessWindow)
        {
            // Show the new WpfViewWindow.
            modelessWindow.Show();
        }
        // Clear the current value so that the next PropertyChanged event
        // is processed even if the underlying value has not actually changed.
        SetCurrentValue(ShowNewViewProperty, null);
    }
