    switch (e.Action)
        {
            case MotionEvent.Down:
                Task.Delay(2000);  
                Task.Factory.StartNew(() => DoSomething(), cancelToken.Token);   
            break;
            case MotionEvent.Move:
                cancelToken.Cancel(false);
            break;
            case MotionEvent.Up:
                 cancelToken.Cancel(false);
            break;
        }
