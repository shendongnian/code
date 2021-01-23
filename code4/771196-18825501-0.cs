    private void MyBorder_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            if (!first)
            {
                DoubleAnimation anim = new DoubleAnimation();
                anim.From = e.PreviousSize.Height;
                anim.To = e.NewSize.Height;
                anim.Duration = new Duration(TimeSpan.FromSeconds(1));
                Storyboard.SetTarget(anim, MyBorder);
                Storyboard.SetTargetProperty(anim, new PropertyPath(Border.HeightProperty));
                Storyboard st = new Storyboard();
                st.Children.Add(anim);
                st.Completed += st_Completed;
                MyBorder.SizeChanged -= MyBorder_SizeChanged_1;
                st.Begin();
            }
            first = false;
        }
        void st_Completed(object sender, EventArgs e)
        {
            MyBorder.SizeChanged += MyBorder_SizeChanged_1;
        }
        private void MyBorder_Tap_1(object sender, GestureEventArgs e)
        {
            if (MyPanel.Visibility == Visibility.Collapsed)
                MyPanel.Visibility = Visibility.Visible;
            else
                MyPanel.Visibility = Visibility.Collapsed;
        }
