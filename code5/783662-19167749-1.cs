public static class TaskLogging
{
	private const BindingFlags StaticBinding = BindingFlags.Static | BindingFlags.NonPublic;
	public static void SetScheduler(TaskScheduler taskScheduler)
	{
		var field = typeof(TaskScheduler).GetField("s_defaultTaskScheduler", StaticBinding);
		field.SetValue(null, taskScheduler);
		SetOnTaskFactory(new TaskFactory(taskScheduler));
	}
	private static void SetOnTaskFactory(TaskFactory taskFactory)
	{
		var field = typeof(Task).GetField("s_factory", StaticBinding);
		field.SetValue(null, taskFactory);
	}
}
