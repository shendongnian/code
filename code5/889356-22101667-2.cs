	using NUnit.Framework;
	namespace ConsoleApplication1
	{
		internal class Program
		{
			private static void Main()
			{
				var viewModel = new ViewModel();
				Assert.That(() => viewModel.SaveCommand_Exec(null, new ExecutedRoutedEventArgs()), Throws.Nothing);
			}
		}
		public class ViewModel
		{
			public bool SaveCommand_Exec(object sender, ExecutedRoutedEventArgs e)
			{
				return true;
			}
		}
		public class ExecutedRoutedEventArgs
		{
		}
	}
