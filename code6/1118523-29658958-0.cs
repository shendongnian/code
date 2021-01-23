	//Returns the top running task information
	private static ActivityManager activityManager;
	private static Android.App.ActivityManager.RunningTaskInfo runningTaskInfo;
	public static ComponentName GetTopActivity()
	{
		if(activityManager == null)
		{
			activityManager = (ActivityManager) Application.Context.GetSystemService(Context.ActivityService);
		}
		IList<Android.App.ActivityManager.RunningTaskInfo> runningTasks = 	
            activityManager.GetRunningTasks(1);
		if(runningTasks != null && runningTasks.Count > 0)
		{
			runningTaskInfo = runningTasks[0];
			return runningTaskInfo.TopActivity;
		}
	    else
		{
			return null;
		}
	}
	//This called from my thread every 2 seconds
	public bool IsAppVisible()
	{
		//have to do a complicated version of this to determine the current running tasks        //and whether our app is the most prominent.
		Android.Content.ComponentName componentName = AndroidUtils.GetTopActivity();
		bool isCurrentActivity;
		if(componentName != null)
		{
			isCurrentActivity = string.Compare(componentName.PackageName, "myPackage") == 0;
		}
		else
		{
			isCurrentActivity = false;
		}
		return isCurrentActivity;
	}
	if(DependencyService.Get<IDeviceUtility>().IsAppVisible() == false)
	{
		//This needs to be manually called if the app becomes completely unresponive
		OnSleep();
		Debug.WriteLine("App is no longer visible");
	}
