    using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	namespace LoginFormTest
	{
		public partial class LoginForm : Form
		{
			public LoginForm()
			{
				InitializeComponent();
			}
			public void doShow(bool bShow)
			{
				if(bShow)
					Invoke(new Action(() => this.Show()));
				else
					Invoke(new Action(() => this.Hide()));
			}
			public void doClose()
			{
				Invoke(new Action(() => this.Close()));
			}
			private void mnuLogin_Click(object sender, EventArgs e)
			{
				MainForm mainForm = new MainForm();
				mainForm.Show();
				System.Diagnostics.Debug.WriteLine("mainForm started");
			}
		}
	}
