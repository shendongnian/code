    public class ControlAdorner: Adorner
    {
        #region Private fields
      
        // Utilized for caching of offset by x co-ordinate.
        private double m_OffsetX = 0d;
        
        // Uri    private double m_OffsetY = 0d;
        #endregion
        
        #region Initialization
        public ControlAdorner( UIElement adornedElement )
            : base( adornedElement )
            {
    
            }
        #endregion
        
        #region Implementation
        //Measures content.
        protected override Size MeasureOverride( Size constraint )
        {
            m_child.Measure( constraint );
            return AdornedElement.RenderSize;
        }
        
        //Arranges child control to the full size.
        protected override Size ArrangeOverride( Size finalSize )
        {
            m_child.Arrange( new Rect( finalSize ) );
            return m_child.RenderSize;
        }
        
        public override GeneralTransform GetDesiredTransform( GeneralTransform transform )
        {
            GeneralTransformGroup group = new GeneralTransformGroup();
            group.Children.Add( transform );
            group.Children.Add( new TranslateTransform( OffsetX, OffsetY ) );
            return group;
        }
        
        //Get visual by index.
        protected override Visual GetVisualChild( int index ) 
        {
            return m_child;
        }
        
        private static void OnOffsetXChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            ControlAdorner instance = (ControlAdorner)d;
            instance.OnOffsetXChanged( e );
        }
        
        private void OnOffsetXChanged( DependencyPropertyChangedEventArgs e )
        {
            m_OffsetX = (double)e.NewValue;
            if( OffsetXChanged != null )
            {
                OffsetXChanged( this, e );
            }
        }
        
        private static void OnOffsetYChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            ControlAdorner instance = (ControlAdorner)d;
            instance.OnOffsetYChanged( e );
        }
        
        private void OnOffsetYChanged( DependencyPropertyChangedEventArgs e )
        {
            m_OffsetY = (double)e.NewValue;
            if( OffsetYChanged \!= null )
            {
                OffsetYChanged( this, e );
            }
        }
        #endregion
        
        #region Events
        public event PropertyChangedCallback OffsetXChanged;
        public event PropertyChangedCallback OffsetYChanged;
        public double OffsetX
        {
            get
            {
                return m_OffsetX;
            }
            set
            {
                SetValue( OffsetXProperty, value );
            }
        }
        public double OffsetY
        {
            get
            {
                return m_OffsetY;
            }
            set
            {
                SetValue( OffsetYProperty, value );
            }
        }
        
        // Gets visual children count, always 1.
        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }
        #endregion
        
        #region Dependency properties
        public static readonly DependencyProperty OffsetXProperty = DependencyProperty.Register( 
          "OffsetX", typeof( double ), typeof( ControlAdorner ),
          new FrameworkPropertyMetadata( 0d,    
            FrameworkPropertyMetadataOptions.AffectsArrange | 
            FrameworkPropertyMetadataOptions.AffectsParentArrange, 
            new PropertyChangedCallback( OnOffsetXChanged ) ) );
        
        public static readonly DependencyProperty OffsetYProperty = DependencyProperty.Register( 
          "OffsetY", typeof( double ), typeof( ControlAdorner ),
          new FrameworkPropertyMetadata( 0d, 
            FrameworkPropertyMetadataOptions.AffectsArrange |
            FrameworkPropertyMetadataOptions.AffectsParentArrange, 
            new PropertyChangedCallback( OnOffsetYChanged ) ) );
        #endregion
    }
