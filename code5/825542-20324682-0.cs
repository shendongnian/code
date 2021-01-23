        private Popup _popup;
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Grid g=new Grid {Height = 400,Width = 480,Background =new SolidColorBrush(Colors.Green)};
            Rectangle r = new Rectangle
                {
                    Height = 50,
                    Width=50,
                    Fill = new SolidColorBrush(Colors.Red),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
            g.Children.Add(r);
            _popup = new Popup()
               {
                   Height = 400,
                   Width = 480,
                   IsOpen = true,
                   Child = g
               };          
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (_popup != null)
            {
                if (_popup.IsOpen)
                {
                    e.Cancel = true;
                    _popup.IsOpen = false;
                }
            }
        }
