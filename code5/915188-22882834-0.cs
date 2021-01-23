	public class InitialiseSettings
	{
		public static void Initialise()
		{
			//Code to run here
		}
		public InitialiseSettings()
		{
			
		}
	}
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//Instantiate an object here of the class or call a static function of that class etc etc
			InitialiseSettings settings = new InitialiseSettings();
			InitialiseSettings.Initialise();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			//Or you could do it here - before the form is displayed
		}
	}
