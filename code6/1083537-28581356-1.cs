	using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using System.Threading;
	namespace LoginFormTest
	{
		public partial class MainForm : Form
		{
			int countDown = 3;  //number of seconds for timeout
			System.Threading.Timer timer;
			object lockCounter = new object(); //to sync access to counter var
			public MainForm()
			{
				InitializeComponent();
				//start a independent timer after 1000ms and with a 1000ms interval
				timer = new System.Threading.Timer(new TimerCallback(this.timerCallback), null, 1000, 1000);
			}
			private void mnuExit_Click(object sender, EventArgs e)
			{
				doClose();
			}
			private void mnuLogout_Click(object sender, EventArgs e)
			{
				doClose();
			}
			private void doClose()
			{
				System.Diagnostics.Debug.WriteLine("mainForm closing");
				try
				{
					timer.Dispose(); //else timer thread will continue running!
					Invoke(new Action(() => this.Close()));
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine("Exception in doClose(): " + ex.Message);
				}
			}
			private void MainForm_MouseMove(object sender, MouseEventArgs e)
			{
				resetTimeout();
			}
			private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
			{
				resetTimeout();
			}
			private void MainForm_Click(object sender, EventArgs e)
			{
				resetTimeout();
			}
			public void resetTimeout()
			{
				System.Diagnostics.Debug.WriteLine("resetTimeout()");
				lock(lockCounter)
					countDown = 3;
			}
			public void timerCallback(object stateInfo)
			{
				lock (lockCounter)
					countDown--;
				if (countDown == 0)
				{
					System.Diagnostics.Debug.WriteLine("timeout->doClose()");
					doClose();
				}
			}
			private void MainForm_Closed(object sender, EventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("mainForm CLOSED");
			}
		}
	}
