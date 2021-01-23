    private void MyBorder_Tap_1(object sender, GestureEventArgs e)
    {
        if (MyPanel.Visibility == Visibility.Collapsed)
        {
            MyPanel.Visibility = Visibility.Visible;
            MyPanel.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            DoubleAnimation anim = new DoubleAnimation();
            anim.From = MyBorder.ActualHeight;
            anim.To = MyBorder.ActualHeight + MyPanel.DesiredSize.Height;
            anim.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            Storyboard.SetTarget(anim, MyBorder);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Border.HeightProperty));
            Storyboard st = new Storyboard();
            st.Children.Add(anim);
            st.Begin();
        }
        else
        {
            MyPanel.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            DoubleAnimation anim = new DoubleAnimation();
            anim.From = MyBorder.ActualHeight;
            anim.To = MyBorder.ActualHeight - MyPanel.DesiredSize.Height;
            anim.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            Storyboard.SetTarget(anim, MyBorder);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Border.HeightProperty));
            Storyboard st = new Storyboard();
            st.Children.Add(anim);
            st.Completed += (a,b) => { MyPanel.Visibility = Visibility.Collapsed; };
            st.Begin();
        }
    }
