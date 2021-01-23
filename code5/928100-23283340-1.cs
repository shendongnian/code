	using System;
	using System.Diagnostics;
	using System.Windows.Forms;
	
	namespace TestApp
	{
		class MainForm : Form
		{
			private Random rd;
			private const int buttonsCount = 42;
			
			public MainForm()
			{
				rd = new Random();
				Text = "Click on me!";
			}
			
			protected override void OnClick(EventArgs e)
			{
				compMode();
			}	
			
			public void compMode()
			{
				int rn = rd.Next(1, buttonsCount);
				Debug.WriteLine("rn is {0}", rn);
			}
			
			public static void Main(string[] args)
			{
				Application.Run(new MainForm());
			}
		}
	}
