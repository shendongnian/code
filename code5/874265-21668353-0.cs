    private void MouseButtonDownHandler(object sender, MouseButtonEventArgs e)
    {
        Control src = e.Source as Control;
    
        if (src != null)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    // do something
                    break;
                case MouseButton.Middle:
                    // do something
                    break;
                case MouseButton.Right:
                    // do something
                    break;
                case MouseButton.XButton1:
                    // do something
                    break;
                case MouseButton.XButton2:
                    // do something
                    break;
                default:
                    break;
            }
        }
    }
