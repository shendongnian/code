    static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            // Show the login form
			LoginForm loginForm = new LoginForm();
			loginForm.ShowDialog();
            // Show the main form
			Application.Run(new MainForm());
		}
	}
	class LoginForm : Form
	{
		public LoginForm()
		{
			BackColor = Color.Blue;
			Text = "Login Form";
		}
	}
	class MainForm : Form
	{
		public MainForm()
		{
			BackColor = Color.Red;
			Text = "Main Form";
		}
	}
