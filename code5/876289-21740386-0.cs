    // Set this to something sensible for your speeds.
    // You may want to have it be calculated on the fly,
    // Such as by doing an even distribution of steps,
    // Possibly with a minimum value for a step to be. Up to you.
    private const double StepSize = 5; 
    private const double StepTime = 1.5;
    private async void OnSpeedChanged(double newSpeedValue) {
        DoubleAnimation animation = new DoubleAnimation();
        animation.EnableDependentAnimation = true;
        PowerEase easing = new PowerEase();
        easing.Power = 5.0;
        easing.EasingMode = EasingMode.EaseOut;
        animation.EasingFunction = easing;
        Storyboard storyboard = new Storyboard();
        storyboard.Children.Add(animation);
        Storyboard.SetTarget(animation, this);
        Storyboard.SetTargetProperty(animation, "Speed");
        // You may want to have this be an absolute value and store the sign
        // in case there is both a positive and negative change in speed
        var difference = newSpeedValue - Speed;
        
        for(double stepValue = Speed + StepSize; i < difference; i += StepSize)
        {
            animation.Duration = new Duration(TimeSpan.FromSeconds(StepTime));
            animation.To = stepValue;
            await storyboard.BeginAsync();
        }
        // do the last one
        animation.Duration = new Duration(TimeSpan.FromSeconds(StepTime));
        animation.To = newSpeedValue;
        await storyboard.BeginAsync();
    }
