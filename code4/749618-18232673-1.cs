    DoubleAnimation a = new DaoubleAnimation();
    a.From = 50;
    a.To = 100;
    a.BeginTime = "0:0:2";
    
    b.BeginAnimation(Button.WidthProperty, a);
