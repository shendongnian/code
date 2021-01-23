    public partial class MainWindow : Window
    {
		private Difficulty _difficulty;
		
		private void Easy_Checked(object sender, RoutedEventArgs e)
		{
			_difficulty = Difficulty.Easy;
		}
		
		private void SomeMethod()
		{
			if (_difficulty == Difficulty.Easy)
			{
				// do something here
			}
		}
	}
