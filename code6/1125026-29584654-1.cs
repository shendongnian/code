	namespace Project
	{
		public partial class AddTask : Form
		{
			private ListDisplay _ld;
			public AddTask(ListDisplay ld)
			{
				_ld = ld;
			}
			
			private void btnSubmit_Click(object sender, EventArgs e)
			{
				_ld.LoadingListBox();
			}
		}
	}
