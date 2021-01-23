      public static readonly DependencyProperty TextProperty =
            TextBlock.TextProperty.AddOwner(typeof(ccTextFigure),
             new FrameworkPropertyMetadata(
                null,                                               
                FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure,    
                propertyChangedCallback: OnTextChanged              
                ));
