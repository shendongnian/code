    public bool NeedsToFire
    {
       get { return (bool)GetValue(NeedsToFireProperty); }
       set { SetValue(NeedsToFireProperty, value); }
    }
    public static readonly DependencyProperty NeedsToFireProperty =
            DependencyProperty.Register("NeedsToFire", typeof(bool), 
                typeof(Firework), new PropertyMetadata(false, HandleNeedsToFire));
    private static void HandleNeedsToFire(DependencyObject d, 
                                          DependencyPropertyChangedEventArgs e)
    {
       if ((bool)e.NewValue)
       {
          (d as Firework).Fire();
       }
    }
