    public class UpperTextBlock : TextBlock
    {
        static UpperTextBlock()
        {
            TextBlock.TextProperty.OverrideMetadata(
                typeof(UpperTextBlock),
                new FrameworkPropertyMetadata(
                    default(PropertyChangedCallback),
                    (CoerceValueCallback)CoerceTextProperty));
        }
        private static object CoerceTextProperty(DependencyObject d, object baseValue)
        {
            if (baseValue is string)
                return ((string)baseValue).ToUpper();
            else
                return baseValue;
        }
    }
