		private void button1_Click(object sender, RibbonControlEventArgs e)
		{
			var taskpane = TaskPaneManager.GetTaskPane("A", "Task pane type A", () => new UserControl1());
			taskpane.Visible = !taskpane.Visible;
		}
		private void button2_Click(object sender, RibbonControlEventArgs e)
		{
			var taskpane = TaskPaneManager.GetTaskPane("B", "Task pane type B", () => new UserControl2());
			taskpane.Visible = !taskpane.Visible;
		}
