            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            _taskFactoryWrapper.StartTask(() => DoSomeWork(viewSettings.AnyValue)).ContinueWith(task =>
            {
              
                    viewSettings.Result= task.Result;
            },TaskContinuationOptions.AttachedToParent)
                .ContinueWith(t => EndingUploadingProgress(viewSettings), uiContext);
