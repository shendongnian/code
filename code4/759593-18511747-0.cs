    if(_refreshTimeTimer != null){
          Timer t = new timer(_refreshTimeTimer );
          // Start new timer
          _refreshTimeTimer = null;
    }else{
          if (_timer.IsEnabled)
              {
                _watcher.Stop();
                _timer.Stop();
                StartButton.Content = "Start";
              }
              else
              {
                _watcher.Start();
                _timer.Start();
                _startTime = System.Environment.TickCount;
                StartButton.Content = "Stop";
              }
    }
