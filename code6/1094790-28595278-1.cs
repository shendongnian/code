    foreach(bool element in Sequence)
    {
        if(element){ ellipse.Fill = new SolidColorBrush(Colors.Yellow); }
        else{ ellipse.Fill = new SolidColorBrush(Colors.Blue); }
        int milisecond = 200;
        Thread.Sleep(miliseconds);
    }
