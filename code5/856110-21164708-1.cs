    public class MyClass
	{
		bool _IsReady = true;
		protected void StatusCheckBoxListChanged(object sender, System.EventArgs e)
		{
			if (!_IsReady)
			{
				return;
			}
			
			//Crazy code I found online to determine which item triggered the event
			CheckBoxList list = (CheckBoxList)sender;
			string[] control = Request.Form.Get("__EVENTTARGET").Split('$');
			int index = control.Length - 1;
			ListItem li = (ListItem)list.Items[Int32.Parse(control[index])];
			if (li.ToString().Equals("Select All")) //If it was the "Select All" Item which triggered the event
			{
				SetAllStatusItemsSelected(StatusCheckBoxList.Items.FindByValue("Select All").Selected);
			}
		}
		
		
		private void SetAllStatusItemsSelected(bool IsSelected)
		{
			_IsReady = false;
			
			//If it was checked, check off everything. If it was unchecked, uncheck everything.
			for(int i = 0; i < StatusCheckBoxList.Items.Count; i++)
			{
				StatusCheckBoxList.Items[i].Selected = StatusCheckBoxList.Items.FindByValue("Select All").Selected;
			}
			
			_IsReady = true;
		}
		
	}
