    public static readonly DependencyProperty BackgroundProperty =
            Panel.BackgroundProperty.AddOwner(
                typeof(Control),
                new FrameworkPropertyMetadata(
                    Panel.BackgroundProperty.DefaultMetadata.DefaultValue,
                    FrameworkPropertyMetadataOptions.None));
