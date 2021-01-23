	public class ListBoxAdder()
	{
		private ListBox _listBox;
		public ListBoxAdder(ListBox listBox)
		{
			_listBox = listBox;
		}
		
	    public void Run()
		{
			string str = "Hello";
			_listbox.Items.Add(str);
		}
	}
	
