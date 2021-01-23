      private void tb_Tap(object sender, System.Windows.Input.GestureEventArgs e)
            {
                ListPicker lp = new ListPicker();
                lp.Background = new SolidColorBrush(Colors.Blue);
                lp.Height = 500;
                LayoutRoot.Children.Add(lp);
            }
