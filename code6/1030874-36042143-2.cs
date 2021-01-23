		private void ForceScriptDefaultConstraint(Table table)
		{
			foreach (Column column in table.Columns)
			{
				if (column.DefaultConstraint != null)
				{
					FieldInfo info = column.DefaultConstraint.GetType().GetField("forceEmbedDefaultConstraint", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
					info.SetValue(column.DefaultConstraint, true);
				}
			}
		}
