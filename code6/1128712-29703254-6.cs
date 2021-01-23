	public static class DialogEvaluator
	{
		public static bool In<T>(this T obj, IEnumerable<T> args)
		{
			return args.Contains(obj);
		}
		
		static DialogEvaluator
		{
			NegativeResult = new List<DialogResult>() { DialogResult.Cancel, DialogResult.Abort, DialogResult.None, DialogResult.No };
			SpecificNegativeResult = new List<DialogResult>() { DialogResult.Cancel, DialogResult.Abort, DialogResult.No };
		}
		
		public static List<DialogResult> NegativeResult {get; private set;}
		public static List<DialogResult> SpecificNegativeResult {get; private set;}
	}
	//And use it like that:
	if (fAuth.ShowDialog(this.DialogParent)
		 .In(DialogEvaluator.NegativeResult)
	{
		return;
	}
	//Or
	if (fAuth.ShowDialog(this.DialogParent)
		 .In(DialogEvaluator.SpecificNegativeResult)
	{
		return;
	}
	
