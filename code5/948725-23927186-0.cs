    [TemplatePart(Name = DisplayColorPart, Type = typeof(Rectangle))]
    [TemplatePart(Name = DropDownPart, Type = typeof(Popup))]
    public class ColorPickerDropDown : Control
    {
        private const string DisplayColorPart = "PART_DisplayColor";
        private const string DropDownPart = "PART_DropDown";
        
        private Rectangle _displayColorElement;
        private Popup _dropDownElement;
        
        public Rectangle DisplayColorElement
        {
            get { return _displayColorElement; }
            set
            {
                _displayColorElement = value;
                InitalizeDisplayColorElement();
            }
        }
        public Popup DropDownElement
        {
            get { return _dropDownElement; }
            set { _dropDownElement = value; }
        }
        public static readonly DependencyProperty CurrentColorProperty =
            DependencyProperty.Register("CurrentColor", typeof(Brush), typeof(ColorPickerDropDown),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Brush CurrentColor
        {
            get { return (Brush)GetValue(CurrentColorProperty); }
            set { SetValue(CurrentColorProperty, value); }
        }
        
        static ColorPickerDropDown()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(ColorPickerDropDown),
                new FrameworkPropertyMetadata(typeof(ColorPickerDropDown)));
       
        }
        public ColorPickerDropDown()
        {
            Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this, OutsideControlClick);
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (DisplayColorElement == null) DisplayColorElement = GetTemplateChild(DisplayColorPart) as Rectangle;
            if (DropDownElement == null) DropDownElement = GetTemplateChild(DropDownPart) as Popup;
        }
        private void InitalizeDisplayColorElement()
        {
            if (DisplayColorElement == null) return;
            DisplayColorElement.AddHandler(Rectangle.MouseLeftButtonDownEvent,
                                           new RoutedEventHandler(DisplayColorClick),
                                           handledEventsToo: true);
        }
        private void DisplayColorClick(object sender, RoutedEventArgs e)
        {
            DropDownElement.IsOpen = DropDownElement.IsOpen ? false : true;
            if (DropDownElement.IsOpen) // ***
            {                           // ***
                Mouse.Capture(this);    // ***
            }                           // ***
        }
        public void OutsideControlClick(object sender, MouseButtonEventArgs e)
        {
            if (!IsWithin(DropDownElement.Child, e) && !IsWithin(DisplayColorElement, e)) // ***
            {
                DropDownElement.IsOpen = false;
                Mouse.Capture(null); // ***
            }
        }
        // *** Is mouse within the bounds of the UI element?
        public static bool IsWithin(UIElement element, MouseButtonEventArgs e)
        {
            FrameworkElement elem = element as FrameworkElement;
            return (elem == null) ? false :
                new Rect(0, 0, elem.ActualWidth, elem.ActualHeight).Contains(e.GetPosition(element));
        }
    }
