	namespace Project
	{
		public partial class AddTask : Form
		{
			private void btnSubmit_Click(object sender, EventArgs e)
			{
				var ld = new ListDisplay();
				ld.Show();
				ld.LoadingListBox();
			}
		}
	}
