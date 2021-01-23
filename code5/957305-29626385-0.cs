		// Generic delegate for cross thread processing
		private void SetProperty<T>(Control ctrl, string propertyName, T propertyValue)
		{
			if (this.InvokeRequired)
				ctrl.Invoke((Action<Control, string, T>)SetProperty, ctrl, propertyName, propertyValue);
			else
			{
				var property = ctrl.GetType().GetProperty(propertyName);
				property.SetValue(ctrl, propertyValue);
			}
		}
		
		public object DataSource
		{
			set
			{
				SetProperty(treeView, "DataSource", value);
			}
		}
