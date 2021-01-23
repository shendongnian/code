     public class HighlightRule
    {
        public SolidColorBrush Brush { get; set; }
        public string MatchText { get; set; }
        public HighlightRule(SolidColorBrush solidColorBrush, string matchText)
        {
            Brush = solidColorBrush;
            MatchText = matchText;
        }
        public HighlightRule(Color color, string matchText)
        {
            Brush = new SolidColorBrush(color);
            MatchText = matchText;
        }
        public HighlightRule()
        {
            MatchText = null;
            Brush = Brushes.Black;
        }
    }
    public class HighlightTextBox : TextBox
    {
        public List<HighlightRule> HighlightRules
        {
            get { return ( List<HighlightRule>)GetValue(HighlightRulesProperty); }
            set { SetValue(HighlightRulesProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HighlightRules.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightRulesProperty =
            DependencyProperty.Register("HighlightRules", typeof(List<HighlightRule>), typeof(HighlightTextBox), new FrameworkPropertyMetadata(new List<HighlightRule>(), new PropertyChangedCallback(HighlightRulesChanged)));
        private static void HighlightRulesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            HighlightTextBox tb = (HighlightTextBox)sender;
            tb.ApplyHighlights();
        }
        public HighlightTextBox() : base()
        {
            this.Loaded += HighlightTextBox_Loaded;
        }
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            ApplyHighlights();
        }
        private void HighlightTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyHighlights();
        }
        static HighlightTextBox()
        {
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    
        public void ApplyHighlights()
        {
            
            this.TryRemoveAdorner<GenericAdorner>();
            foreach(HighlightRule rule in HighlightRules)
            {
                if (!string.IsNullOrEmpty(rule.MatchText) && !string.IsNullOrEmpty(Text) &&
                    Text.ToLower().Contains(rule.MatchText.ToLower()))
                {
                    if (base.ActualHeight != 0 && base.ActualWidth != 0)
                    {
                        int indexOf = 0;
                        do
                        {
                            indexOf = Text.IndexOf(rule.MatchText, indexOf);
                            if (indexOf == -1) break;
                            Rect rect = base.GetRectFromCharacterIndex(indexOf);
                            Rect backRect = base.GetRectFromCharacterIndex(indexOf + rule.MatchText.Length - 1, true);
                            this.TryAddAdorner<GenericAdorner>(new GenericAdorner(this, new Rectangle()
                            { Height = rect.Height, Width = backRect.X - rect.X, Fill = rule.Brush, Opacity = 0.5 }));
                            indexOf++;
                        } while (true);
                    }
                }
            }
           
        }
   
    }
