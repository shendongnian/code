    [TemplatePart(Name = PartLabelName, Type = typeof (TextBlock))]
    [TemplatePart(Name = PartEditorName, Type = typeof (ContentPresenter))]
    public class NumericUpDownEditor : Editor
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof (double), typeof (NumericUpDownEditor), new PropertyMetadata(default(double)));
        private ContentPresenter _partEditorControl;
        private TextBlock _partLabel;
        public double Value
        {
            get { return (double) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _partLabel = GetTemplateChild(PartLabelName) as TextBlock;
            _partEditorControl = GetTemplateChild(PartEditorName) as ContentPresenter;
            if (_partLabel == null || _partEditorControl == null)
            {
                throw new NullReferenceException("Template parts are not available");
            }
        }
    }
