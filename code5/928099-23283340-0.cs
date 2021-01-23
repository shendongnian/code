	using System;
	using System.Diagnostics;
	using System.Windows.Forms;
	
	namespace TestApp
	{
		class MainForm : Form
		{
			private Random rd;
			private const int buttonsCount = 5;
			
			public MainForm()
			{
				rd = new Random();
				this.Text = "Click on me!";
			}
			
			protected override void OnClick(EventArgs e)
			{
				compMode();
			}	
			
			public void compMode()
			{
				int rn = rd.Next(1, 42);
				Debug.WriteLine("rn is {0}", rn);
			}
			
			public static void Main(string[] args)
			{
				Application.Run(new MainForm());
			}
		}
	}
