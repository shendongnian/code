         public class ListViewItemID : ListViewItem
		{
			public int ID {get;set}
		}
	public class CheckBoxID : CheckBox
		{
			public int ID {get;set}
		}
	public class program
		{
			void main()
			{
				var itemOne = new ListViewItemID();
				itemOne.ID = 1;
				var itemTwo = new ListViewItemID();
				itemTwo.ID = 2;
				
				var checkBoxOne = new CheckBoxID();
				checkBoxOne.ID = itemOne.ID;
				var checkBoxTwo = new CheckBoxID();
				checkBoxTwo.ID = itemTwo.ID;
				
			}
			//You could start this in a endless loop in a new thread.
			void HideCheckBox(ListViewItemID item, CheckBoxID checkBox)
			{
				if(item.ID==checBox.ID && checkbox.Checked && item.Text =="done")
				{
					checkBox.Visbile = false;
				}
			}
		}
