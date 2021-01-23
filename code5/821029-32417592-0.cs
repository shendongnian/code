			{
				DataGridTextColumn dgtc = new DataGridTextColumn();
				dgtc.Header = "End Time";
				dgtc.Binding = new Binding("EndTime");
				dgtc.Binding.StringFormat = "{0:hh}:{0:mm}";
				ScheduleGrid.Columns.Add(dgtc);
			}
