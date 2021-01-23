        static EditLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditLabel), new FrameworkPropertyMetadata(typeof(EditLabel)));
        }
        private Label _label;
        public Label Label
        {
            get { return _label; }
            set { _label = value; }
        }
       
        public static readonly  DependencyProperty LabelWidthProperty = DependencyProperty.Register("LabelWidth", typeof(int), typeof(EditLabel), 
                                                                        new PropertyMetadata(10, new PropertyChangedCallback(OnLabelChanged)));
        
        [Description("Establece el ancho de la etiqueta de descripción"), Category("Lutx")]
        public int LabelWidth
        {
            get
            {
                return (int)GetValue(LabelWidthProperty);
            }
            set
            {
                SetValue(LabelWidthProperty, value);          
            }
        }
        private static void OnLabelChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
           EditLabel el  = obj as EditLabel;
           el.Label.Width = (int)e.NewValue;
           //Label lbl = el.GetTemplateChild("PART_Label") as Label;
           //lbl.Width(int)e.NewValue;          
            
         }
        public override void OnApplyTemplate()
        {
            //_txtBox = GetTemplateChild("PART_TextBox") as ButtonEdit;
            _label = GetTemplateChild("PART_Label") as Label;
            
            
            SetBinding(LabelWidthProperty, new Binding
                            {
                                Source = _label,
                                Path = new PropertyPath("Width")
                            });
        }
    }    
