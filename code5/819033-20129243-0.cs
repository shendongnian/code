        public string ToolTipText 
        { 
            get { return (string)this.GetValue(ToolTipTextProperty); }
            set { this.SetValue(ToolTipTextProperty, value); }
        }
        public static object GetToolTipText(DependencyObject target)
        {
            return (object)target.GetValue(ToolTipTextProperty);
        }
        public static void SetToolTipText(DependencyObject target, Object value)
        {
            target.SetValue(ToolTipTextProperty, value);
        }
        public static readonly DependencyProperty ToolTipTextProperty = DependencyProperty.RegisterAttached("ToolTipText", typeof(string), typeof(Controls.ProgressSlider), new PropertyMetadata("0%"));
