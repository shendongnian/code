        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            var direction = -1;
            while (true)
            {
                var percent = rnd.Next(0, 100);
                direction *= -1; // Direction changes every iteration
                var rotation = (int)((percent / 100d) * 45 * direction); // Max 45 degree rotation
                var duration = (int)(750 * (percent / 100d)); // Max 750ms rotation
                var da = new DoubleAnimation
                {
                    To = rotation,
                    Duration = new Duration(TimeSpan.FromMilliseconds(duration)),
                    AutoReverse = true // makes the balloon come back to its original position
                };
                var rt = new RotateTransform();
                Balloon.RenderTransform = rt; // Your balloon object
                rt.BeginAnimation(RotateTransform.AngleProperty, da);
                await Task.Delay(duration * 2); // Waiting for animation to finish, not blocking the UI thread
            }
        }
