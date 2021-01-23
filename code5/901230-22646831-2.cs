    public partial class SplitFlapLetter
    {
        public SplitFlapLetter()
        {
            InitializeComponent();
        }
        public char Letter
        {
            get { return (char)GetValue(LetterProperty); }
            set { SetValue(LetterProperty, value); }
        }
        public static readonly DependencyProperty LetterProperty =
            DependencyProperty.Register("Letter", typeof(char), typeof(SplitFlapLetter), new UIPropertyMetadata(OnLetterChanged));
        private char Letter1
        {
            get { return (char)GetValue(Letter1Property); }
            set { SetValue(Letter1Property, value); }
        }
        public static readonly DependencyProperty Letter1Property =
            DependencyProperty.Register("Letter1", typeof(char), typeof(SplitFlapLetter), new UIPropertyMetadata(null));
        private char Letter2
        {
            get { return (char)GetValue(Letter2Property); }
            set { SetValue(Letter2Property, value); }
        }
        public static readonly DependencyProperty Letter2Property =
            DependencyProperty.Register("Letter2", typeof(char), typeof(SplitFlapLetter), new UIPropertyMetadata(null));
        private bool _isLetter1Active;
        private static void OnLetterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uc = d as SplitFlapLetter;
            if (uc == null) return;
            if (uc._isLetter1Active)
                uc.Letter2 = uc.Letter;
            else
                uc.Letter1 = uc.Letter;
            var sb = uc.FindResource(uc._isLetter1Active ? "GotoLetter2Animation" : "GotoLetter1Animation") as Storyboard;
            if (sb != null) sb.Begin();
            uc._isLetter1Active = !uc._isLetter1Active;
        }
        private readonly List<char> _letters = new List<char> { 'A', 'B', 'C', 'D', 'E' };
        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            Letter = _letters[(_letters.IndexOf(Letter) + 1) % _letters.Count];
        }
    }
