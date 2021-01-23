     public ICommand Progress {
            get {
                return new Command(async () => {
                    var cancelled = false;
                    using (var dlg = dialogService.Progress("Test Progress")) {
                        dlg.SetCancel(() => cancelled = true);
                        while (!cancelled && dlg.PercentComplete < 100) {
                            await Task.Delay(TimeSpan.FromMilliseconds(500));
                            dlg.PercentComplete += 2;
                        }
                    }
                    this.Result = (cancelled ? "Progress Cancelled" : "Progress Complete");                    
                });
            }
        }
