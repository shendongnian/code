            public void Execute(object parameter)
            {
                DateTime finishTime = DateTime.UtcNow + TimeSpan.FromSeconds(5);
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(100);
                timer.Tick += (sender, e) =>
                {
                    TimeSpan timeLeft = finishTime - DateTime.UtcNow;
                    if (timeLeft <= TimeSpan.Zero)
                    {
                        timer.Stop();
                        timeLeft = TimeSpan.Zero;
                        _running = false;
                        OnCanExecuteChanged();
                    }
                    _timerModel.TimeLeft = timeLeft;
                };
                timer.Start();
                _running = true;
                OnCanExecuteChanged();
            }
