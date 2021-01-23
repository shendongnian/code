    public static readonly DependencyProperty RecordContainerGenerationModeProperty = DependencyProperty.Register(
        "RecordContainerGenerationMode", 
        typeof(ItemContainerGenerationMode), 
        typeof(XamDataGrid), 
        new PropertyMetadata(ItemContainerGenerationMode.PreLoad, OnRecordContainerGenerationModeChanged));
    
    
    private static void OnRecordContainerGenerationModeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
        XamDataGrid control = obj as XamDataGrid;
    
        if (control != null)
        {
            ItemContainerGenerationMode newMode = (ItemContainerGenerationMode)args.NewValue;
            if (newMode != ItemContainerGenerationMode.PreLoad)
            {
                control.RecordContainerGenerationMode = ItemContainerGenerationMode.PreLoad;
            }
        }
    }
