	public class MyNumericUpDown : NumericUpDown
	{
		protected override void UpdateEditText()
		{
			base.UpdateEditText();
			ChangingText = true;
			Text += "%";
		}
	}
