        public static Task<int> ShowAlertDialogAsync(UIViewController parent, string stackTrace, int actionCode = 0)
            {
                bool isDebug = false;
    
        // #if DEBUG
                isDebug = true;
        //#endif
               
               var taskCompletionSource = new TaskCompletionSource<int>();
    
                var alert = UIAlertController.Create(ERROR, stackTrace, UIAlertControllerStyle.Alert);
                if (alert.PopoverPresentationController != null)
                {
                    alert.PopoverPresentationController.SourceView = parent.View;
                    alert.PopoverPresentationController.SourceRect = parent.View.Bounds;
                }
    
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default,
                    a => taskCompletionSource.SetResult(0)));
                if (isDebug && actionCode == OKACTIONCODE)
                {
                    alert.AddAction(UIAlertAction.Create("Info", UIAlertActionStyle.Default,
                        a => taskCompletionSource.SetResult(1)));
                }
    
                parent.PresentViewController(alert, true, null);
                
                return taskCompletionSource.Task;
            }
     
