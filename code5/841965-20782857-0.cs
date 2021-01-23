    private static void ButtonsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
       {
        WCCSegmentControl control = (WCCSegmentControl)d;
        control.button.Click += new RoutedEventHandler(segmentcontrolButtonClick);
       }
