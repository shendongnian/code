    switch (e.Action)
        {
            case MotionEvent.Down:
                Task.Delay(2000, cancelToken.Token).ContinueWith(() => DoSomething(),TaskScheduler.FromCurrentSynchronizationContext());   
            break;
            case MotionEvent.Move:
                cancelToken.Cancel(false);
            break;
            case MotionEvent.Up:
                 cancelToken.Cancel(false);
            break;
        }
