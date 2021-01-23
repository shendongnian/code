    private void OnFlick(object sender, FlickGestureEventArgs e)
        {
            if (e.Direction == System.Windows.Controls.Orientation.Horizontal)
            {
                // User flicked towards left ==== show main panel
                if (e.HorizontalVelocity < 0)
                {
                    SlideLeftAnimation.Begin();
                }
                // User flicked towards right  ===== show left panel
                else if (e.HorizontalVelocity > 0)
                {
                    SlideRightAnimation.Begin();
                }
            }
        }
