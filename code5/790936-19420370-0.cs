    public class MyCollection : System.Collections.ObjectModel.Collection<MyFrac>
	{
		protected override void InsertItem(int index, MyFrac item)
		{
			if(item == null) return;
			base.InsertItem(index, item);
		}		
		
		protected override void SetItem(int index, MyFrac item)
		{
			if(item == null) 
			{
				base.RemoveAt(index);
			}
			else
			{
				base.SetItem(index, item);
			}
		}
	}
