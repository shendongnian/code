	using System;
	using System.Windows.Forms;
		
	namespace TestApp
	{
		public class FormA : Form
		{
			private readonly Button buttonA;
	
			public virtual void ButtonAClick(object sender, EventArgs e)
			{
				MessageBox.Show("FormA");
			}
			
			public FormA()
			{
				this.buttonA = new Button()
				{
					Text = "buttonA",
					Top = 10,
					Left = 10
				};
				this.buttonA.Click += ButtonAClick;
				this.Controls.Add(buttonA);
			}
		}
		
		public class FormB : FormA
		{
			public override void ButtonAClick(object sender, EventArgs e)
			{
				MessageBox.Show("FormB");
				base.ButtonAClick(sender, e);
			}
		}
		
		class Program
		{
			public static void Main(string[] args)
			{
				Application.Run(new FormB());
			}
		}
	}
