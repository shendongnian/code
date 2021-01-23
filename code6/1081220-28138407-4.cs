    public partial class MainWindow : Window
    {
		// ...
		
		private void AtSomeLaterPoint()
		{
            // open another window and pass the difficulty via its constructor
			var otherWindow = new OtherWindow(_difficulty);
            otherWindow.Show();
		}
	}
    
    public partial class OtherWindow : Window
    {
		private Difficulty _difficulty;
        public OtherWindow(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }
	}
