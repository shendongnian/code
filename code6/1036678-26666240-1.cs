    private void OnFlick(object sender, FlickGestureEventArgs e)
    {
        double swipe_velocity = 1000;
        // User flicked towards left
        if (e.HorizontalVelocity < -swipe_velocity)
        {
            // Load the next image 
        }
        // User flicked towards right
        if (e.HorizontalVelocity > swipe_velocity)
        {
            // Load the previous image
        }
    }
