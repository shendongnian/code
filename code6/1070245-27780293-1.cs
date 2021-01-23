        public ColorBindingProvider()
        {
            App.Current.Resuming += App_Resuming;
        }
        private async void App_Resuming(object sender, object e)
        {
            // Delay 1ms (see answer to your first question)
            await Task.Delay(1);
            TextColor = new SolidColorBrush((Color)Application.Current.Resources["PhoneForegroundColor"]);
        }
        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(ColorBindingProvider), new PropertyMetadata(null));
    }
