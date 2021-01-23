    switch (e.Action)
        {
            case MotionEvent.Down:
                Task.Delay(2000, cancelToken.Token).ContinueWith(state => DoSomething(),TaskScheduler.FromCurrentSynchronizationContext());   
            break;
            case MotionEvent.Move:
                cancelToken.Cancel(false);
            break;
            case MotionEvent.Up:
                 cancelToken.Cancel(false);
            break;
        }
