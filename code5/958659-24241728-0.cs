    public class MyAnimatedControl : Button
    {
    
        protected override void OnClick()
        {
            base.OnClick();
            DoubleAnimation a = new DoubleAnimation(ActualHeight + 20,
                                      new Duration(TimeSpan.FromMilliseconds(500)));
            a.Completed += (s, e) =>
            {
                BeginAnimation(Button.HeightProperty, null); // Remove animation.
                SetCurrentValue(Button.HeightProperty, ActualHeight); // Set value.
            };
            this.BeginAnimation(Button.HeightProperty, a);
        }
    }
