	public class DialogEvaluator
	{
		public static bool IsResultNegative(DialogResult result)
		{
			switch(fAuth.ShowDialog(this.DialogParent))
			{
				case DialogResult.Cancel:
				case DialogResult.Abort:
				case DialogResult.None:
				case DialogResult.No:
					return true;
				default:
					return false;
			}
		}
	}
	//And use it like that:
	if(DialogEvaluator.IsResultNegative(fAuth.ShowDialog(this.DialogParent))
	{
		return;
	}
