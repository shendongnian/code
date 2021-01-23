    public class MyVector : DependencyObject
    {
        public static readonly DependencyProperty BeginProperty;
        public static readonly DependencyProperty EndProperty;
        public static readonly DependencyProperty LengthProperty;
        public int? Begin
        {
            get { return (int?)GetValue(BeginProperty); }
            set { SetValue(BeginProperty, value); }
        }
        public int? End
        {
            get { return (int?)GetValue(EndProperty); }
            set { SetValue(EndProperty, value); }
        }
        public int Length
        {
            get { return (int)GetValue(LengthProperty); }
        }
        public void Resize(int newLength)
        {
            if (newLength < 0)
                throw new ArgumentOutOfRangeException("newLength"");
            if (this.Begin == null)
                this.Begin = 1;
            this.End = this.Begin + newLength;
        }
        static MyVector()
        {
            BeginProperty = DependencyProperty.Register(
                "Begin",
                typeof(int?),
                typeof(MyVector),
                new PropertyMetadata(default(int?), OnBeginChanged, CoerceBegin));
            EndProperty = DependencyProperty.Register(
                "End",
                typeof(int?),
                typeof(MyVector),
                new PropertyMetadata(default(int?), OnEndChanged, CoerceEnd));
            var lengthKey = DependencyProperty.RegisterReadOnly(
                "Length",
                typeof(int?),
                typeof(MyVector),
                new PropertyMetadata(default(int), null, CoerceLength));
            LengthProperty = lengthKey.DependencyProperty;
        }
        private static void OnBeginChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(EndProperty);
            d.CoerceValue(LengthProperty);
        }
        private static object CoerceBegin(DependencyObject d, object baseValue)
        {
            var vector = (MyVector)d;
            var begin = (int?)baseValue;
            if (begin > vector.End)
                return vector.End;
            if (begin % 2 == 0)
                return begin == 0 ? 1 : begin - 1;
            return baseValue;
        }
        private static void OnEndChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(BeginProperty);
            d.CoerceValue(LengthProperty);
        }
        private static object CoerceEnd(DependencyObject d, object baseValue)
        {
            var vector = (MyVector)d;
            var end = (int?)baseValue;
            if (end < vector.Begin)
                return vector.Begin;
            if (end % 2 == 0)
                return end + 1;
            return baseValue;
        }
        private static object CoerceLength(DependencyObject d, object baseValue)
        {
            var vector = (MyVector)d;
            return (vector.End - vector.Begin) ?? 0;
        }
        public override string ToString()
        {
            return string.Format(
                "[MyVector Begin: {0}, End: {1}, Length: {2}]",
                Begin,
                End,
                Length);
        }
    }
