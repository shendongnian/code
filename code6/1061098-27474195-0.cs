     public static readonly DependencyProperty RichTextProperty =
            DependencyProperty.Register(
            "RichText",                                 
            typeof(Paragraph),                          
            typeof(InkTextBlock),                       
            new FrameworkPropertyMetadata(
                null,                                               
                FrameworkPropertyMetadataOptions.AffectsRender,     
                OnRichTextPropertyChanged                           
                )                            
            );
