    public event EventHandler SelectionChanged;
    
    private static void OnSelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var hub = d as SelectionHub;
        if (hub == null) return;
    
        // do not try to set the section when the user is swiping
        if (hub._settingIndex) return;
 
        // No sections?!?
        if (hub.Sections.Count == 0) return;
        hub.OnSelectionChanged();
    }
    
    private void OnSelectionChanged()
    {
        var section = Sections[SelectedIndex];
        ScrollToSection(section);
        var handler = SelectionChanged;
        if(handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
