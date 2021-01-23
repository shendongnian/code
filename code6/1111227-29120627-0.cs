	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	namespace WindowsFormsApplication2
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			public static int t = 1800;
			public static bool msg = false;
			private void Form1_Load(object sender, EventArgs e)
			{
				timer1.Enabled = true;
				timer1.Interval = t;
			}
			private void timer1_Tick(object sender, EventArgs e)
			{
				if (msg == false)
				{
					msg = true;
					MessageBox.Show("Some text here.", "");
					msg = false;
				}
			}
		}
	}
