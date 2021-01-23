        private void setupBackgroundTask() {
			requestAccess();
			UnregisterBackgroundTask();
			RegisterBackgroundTask();
		}
		private void RegisterBackgroundTask() {
			BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();
			PushNotificationTrigger trigger = new PushNotificationTrigger();
			taskBuilder.SetTrigger(trigger);
			taskBuilder.TaskEntryPoint = "Tasks.NotificationReceiver";
			taskBuilder.Name = "pushTask";
			try {
				BackgroundTaskRegistration task = taskBuilder.Register();
				Logger.log("TASK REGISTERED");
			} catch (Exception ex) {
				Logger.log("FAILED TO REGISTER TASK");
				UnregisterBackgroundTask();
			}
		}
		private bool UnregisterBackgroundTask() {
			foreach (var iter in BackgroundTaskRegistration.AllTasks) {
				IBackgroundTaskRegistration task = iter.Value;
				if (task.Name == "pushTask") {
					task.Unregister(true);
					Logger.log("TASK UNREGISTERED");
					return true;
				}
			}
			return false;
		}
		private async void requestAccess() {
			BackgroundAccessStatus backgroundStatus = await BackgroundExecutionManager.RequestAccessAsync();
		}
