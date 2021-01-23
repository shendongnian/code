    public class RespondingTextBox : System.Windows.Forms.TextBox
	{
		public RespondingTextBox()
		{
			PreviewKeyDown += txtBox_PreviewKeyDown;
		}
		void txtBox_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
		{
			e.IsInputKey = true;
		}
	}
