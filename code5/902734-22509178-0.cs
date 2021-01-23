	public static class FormHelper
	{
		public static DisplayResult ShowForm<T>(IWin32Window owner, bool canShowForm)
			where T : Form, new()
		{
			if (canShowForm)
			{
				T form = new T();
			
				return form.ShowDialog(owner);
			}
			else
			{
				MessageBox.Show("You don't have enough rights to view this form.");
			}
		}
	}
