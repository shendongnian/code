    Observable.FromEventPattern<MouseEventArgs>(grid, "MouseMove")
        .Select(e => Tuple.Create(e.EventArgs.Source as UIElement, e.EventArgs))
        .Sample(TimeSpan.FromSeconds(1))
        .Subscribe(mouseMoveRxSample);
    // ...
    private void mouseMoveRxSample(Tuple<UIElement, MouseEventArgs> obj)
    {
        var element = obj.Item1;
        //element is System.Windows.Controls.Button
    }
