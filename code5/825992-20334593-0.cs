        public class ReusableContainer : ContentControl
        {
            public static readonly DependencyProperty ButtonProperty = DependencyProperty.Register("Button", typeof(Button), typeof(ReusableContainer), new PropertyMetadata(default(Button)));
    
            public Button Button
            {
                get { return (Button)GetValue(ButtonProperty); }
                set { SetValue(ButtonProperty, value); }
            }
        }
