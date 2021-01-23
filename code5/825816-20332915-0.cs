    /// <summary>
    /// BUTTON COMMAND: The iCommand of the button
    /// </summary>
    /// <remarks></remarks>
    public ICommand ButtonCommand {
    	get { return GetValue(ButtonCommandProperty); }
    	set { SetValue(ButtonCommandProperty, value); }
    }
    
    public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(CustomListViewControl ), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    /// <summary>
    /// BUTTON COMMAND: The iCommandParameter of the button
    /// </summary>
    /// <remarks></remarks>
    public ObservableCollection<T> ButtonCommandParameter {
    	get { return GetValue(ButtonCommandParameterProperty); }
    	set { SetValue(ButtonCommandParameterProperty, value); }
    }
    public static readonly DependencyProperty ButtonCommandParameterProperty = DependencyProperty.Register("ButtonCommandParameter", typeof(ObservableCollection<T>), typeof(CustomListViewControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
