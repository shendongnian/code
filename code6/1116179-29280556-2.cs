	public partial class Production_Optimization_Window : Window
	{
		Ingredient strawberry;
		Recipe strawberryrecipe;
		public Production_Optimization_Window()
		{
			InitializeComponent();
			
			// This will use the field "strawberryrecipe"
            strawberryrecipe = new Recipe();
			strawberryrecipe.Type = "asd";
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(strawberryrecipe.Type);
		}
	}
