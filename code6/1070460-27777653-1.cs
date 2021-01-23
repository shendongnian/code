    switch (e.Action)
        {
            case MotionEvent.Down:
                Task.Delay(2000, cancelToken.Token).ContinueWith(() => DoSomething());   
            break;
            case MotionEvent.Move:
                cancelToken.Cancel(false);
            break;
            case MotionEvent.Up:
                 cancelToken.Cancel(false);
            break;
        }
