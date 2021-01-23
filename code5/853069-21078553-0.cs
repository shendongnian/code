    private AudioVideoCaptureDevice _cam;
    ...
         protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
            {
                _isNavigatingFrom = true;
                if (CameraIsRecording)
                {
    /*
    var task = DoStopRecording();
    task.Start();
    task.Wait();
    */
                }
                TheMoveJoystick.StopJoystick();
                ViewModel.AccelMovement.EnsureAccelerometerIsOnCommand.Execute(false);
                ViewModel.Speech.EnsureSpeechIsOn.Execute(false);
                ViewModel.AccelMovement.PropertyChanged -= AccelMovementOnPropertyChanged;
                _hackTimer.Stop();
                if (_cam != null)
                {
                    _cam.Dispose();
                    _cam = null;
                }
                _isNavigatingFrom = false;
                base.OnNavigatingFrom(e);
            }
