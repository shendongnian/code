	public partial class Production_Optimization_Window : Window
	{
		Ingredient strawberry;
		Recipe strawberryrecipe;
		public Production_Optimization_Window()
		{
			InitializeComponent();
			
		   strawberryrecipe.Type = "asd";
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
		  MessageBox.Show(blueberryrecipe.Type);  //Here i get the error, and blueberry recipe.type = null.
		}
	}
