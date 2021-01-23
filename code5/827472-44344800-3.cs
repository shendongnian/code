    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            this.SuperScriptText = new DelegateCommand<FrameworkElement>(SuperScriptTextCommandHandler);
        }
        private void SuperScriptTextCommandHandler(FrameworkElement obj)
        {
            var rtb = obj as RichTextBox;
            if (rtb != null)
            {
                var currentAlignment = rtb.Selection.GetPropertyValue(Inline.BaselineAlignmentProperty);
                BaselineAlignment newAlignment = ((BaselineAlignment)currentAlignment == BaselineAlignment.Superscript) ? BaselineAlignment.Baseline : BaselineAlignment.Superscript;
                rtb.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, newAlignment);
            }
        }
        public ICommand SuperScriptText { get; set; }
    }
