    public sealed partial class Theme : ComponentBase
    {
        private Color backgroundColor;
        [Category("Theme")]
        [DisplayName("Background Color")]
        [Editor(typeof (ThemeTypeEditor), typeof (UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof (ThemeColorConverter))]
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { SetField(ref backgroundColor, value); }
        }
        private Color foregroundColor;
        [Category("Theme")]
        [DisplayName("Foreground Color")]
        [Editor(typeof(ThemeTypeEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(ThemeColorConverter))]
        public Color ForegroundColor
        {
            get { return foregroundColor; }
            set { SetField(ref foregroundColor, value); }
        }
        private Color highlightColor;
        [Category("Theme")]
        [DisplayName("Highlight Color")]
        [Editor(typeof(ThemeTypeEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(ThemeColorConverter))]
        public Color HighlightColor
        {
            get { return highlightColor; }
            set { SetField(ref highlightColor, value); }
        }
        private Color borderColor;
        [Category("Theme")]
        [DisplayName("Border Color")]
        [Editor(typeof(ThemeTypeEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(ThemeColorConverter))]
        public Color BorderColor
        {
            get { return borderColor; }
            set { SetField(ref borderColor, value); }
        }
        private Color themeColor;
        [Category("Theme")]
        [DisplayName("Theme Color")]
        [Editor(typeof(ThemeTypeEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(ThemeColorConverter))]
        public Color ThemeColor
        {
            get { return themeColor; }
            set { SetField(ref themeColor, value); }
        }
    }
