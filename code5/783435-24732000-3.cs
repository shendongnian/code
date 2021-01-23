    public class TaskPaneManager
	{
		static Dictionary<string, CustomTaskPane> _createdPanes = new Dictionary<string, CustomTaskPane>();
		/// <summary>
		/// Gets the taskpane by name (if exists for current excel window then returns existing instance, otherwise uses taskPaneCreatorFunc to create one). 
		/// </summary>
		/// <param name="taskPaneId">Some string to identify the taskpane</param>
		/// <param name="taskPaneTitle">Display title of the taskpane</param>
		/// <param name="taskPaneCreatorFunc">The function that will construct the taskpane if one does not already exist in the current Excel window.</param>
		public static CustomTaskPane GetTaskPane(string taskPaneId, string taskPaneTitle, Func<UserControl> taskPaneCreatorFunc)
		{
			string key = string.Format("{0}({1})", taskPaneId, Globals.ThisAddIn.Application.Hwnd);
			if (!_createdPanes.ContainsKey(key))
			{
				var pane = Globals.ThisAddIn.CustomTaskPanes.Add(taskPaneCreatorFunc(), taskPaneTitle);
				_createdPanes[key] = pane;
			}
			return _createdPanes[key];
		}
	}
