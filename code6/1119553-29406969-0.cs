        function changeBGColor(this migth be an event handler)
        {
                 Storyboard sb=new storyboard();
                 ColorAnimation ca=new ColorAnimation();
                 ca.From = Colors.Teal;
                 ca.By = Colors.Green;
                 ca.To = Colors.YellowGreen;
                 ca.Duration = new Duration(TimeSpan.FromSeconds(1.5));
                 Storyboard.SetTargetProperty(ca, new PropertyPath("(Background.BackgroundBrus).(SolidColorBrush.Color)"));
                 myWindow1.beginStoryboard(sb);
        }
