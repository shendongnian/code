		System.Windows.Window w = new System.Windows.Window();
		w.TaskbarItemInfo = new System.Windows.Shell.TaskbarItemInfo() { ProgressState = System.Windows.Shell.TaskbarItemProgressState.Normal };
		w.Loaded += delegate {
			Action<Object> callUpdateProgress = (o) => {
				w.TaskbarItemInfo.ProgressValue = (double) o;
			};
			Thread t = new Thread(() => {
				for (int i = 1; i <= 10; i++) {
					w.Dispatcher.BeginInvoke(callUpdateProgress, 1.0 * i / 10);
					Thread.Sleep(1000);
				}
			});
			t.Start();
		};
		System.Windows.Application app = new System.Windows.Application();
		app.Run(w);
