	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Runtime.InteropServices;
	// not here
	namespace WindowsFormsApplication1
	{
		// not here
		public partial class Form1 : Form
		{
			// put it INSIDE the class
		
			[DllImport("user32.dll")]
			public static extern short GetAsyncKeyState(int vKey);
			public Form1()
			{
                // not inside methods, though
				InitializeComponent();
			}
		}
	}
