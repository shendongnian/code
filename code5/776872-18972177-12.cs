    public class YourBaseView : UserControl
    {
        public static readonly DependencyProperty PrimaryButtonProperty =
            DependencyProperty.Register("PrimaryButton", typeof(Button), typeof(YourBaseView), new PropertyMetadata(null));
        public Button PrimaryButton
        {
            get { return (Button)GetValue(PrimaryButtonProperty); }
            set { SetValue(PrimaryButtonProperty, value); }
        }  
        /* and so on */
    }
