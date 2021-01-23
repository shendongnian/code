    public bool OnTouch(Android.Views.View v, Android.Views.MotionEvent e)
    {
        switch (e.Action)
        {
            case MotionEventActions.Down:
                System.Console.WriteLine("OnTouch > Down");
                // Start Animation (change alpha imageviews in list to 100%)
                break;
            case MotionEventActions.Move:
                System.Console.WriteLine("OnTouch > Move");
                // Do something...
                break;
            case MotionEventActions.Up:
                System.Console.WriteLine("OnTouch > Up");
                // End Animation (change alpha imageviews in list to 50%)
                break;
            case MotionEventActions.Cancel:
                System.Console.WriteLine("OnTouch > Cancel");
                // End Animation (change alpha imageviews in list to 50%)
                break;
        }
        return true;
    }
