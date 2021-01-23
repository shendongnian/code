    public void SetOpacity(int newValue)
    {
       Dispatcher.BeginInvoke(new Action(() =>
       {
          lblDrag2.Opacity = newValue;
       }));
    }
