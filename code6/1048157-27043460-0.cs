    >         var keypress =
    >                 Observable.FromEventPattern<KeyEventArgs>(this, "KeyDown")
    >                     .Sample(TimeSpan.FromMilliseconds(100))
    >                     .Subscribe(
    >                         args =>
    >                         {
    >                             if (args.EventArgs.Key == Key.H)
    >                             {
    >                                 //Jatek.Player.Hack();
    >                             }
    >                             else if (args.EventArgs.Key == Key.Up)
    >                             {
    >                                 jatek.PlayerMovement(MozgasIrany.Up, Field);
    > 
    >                             }
    >                             else if (args.EventArgs.Key == Key.Down)
    >                             {
    >                                 jatek.PlayerMovement(MozgasIrany.Down, Field);
    >                             }
    >                             else if (args.EventArgs.Key == Key.Left)
    >                             {
    >                                 jatek.PlayerMovement(MozgasIrany.Left, Field);
    >                             }
    >                             else if (args.EventArgs.Key == Key.Right)
    >                             {
    >                                 jatek.PlayerMovement(MozgasIrany.Right, Field);
    >                             }
    >                         });
