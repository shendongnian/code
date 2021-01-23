	using System.Drawing;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	namespace Test1
	{
		public partial class Form1 : Form
		{
			[DllImport("user32.dll")]
			public static extern bool SetCursorPos(int X, int Y);
			[DllImport("user32.dll")]
			public static extern bool GetCursorPos(out POINT lpPoint);
			[StructLayout(LayoutKind.Sequential)]
			public struct POINT
			{
				public int X;
				public int Y;
				public static implicit operator Point(POINT point)
				{
					return new Point(point.X, point.Y);
				}
			}
			public Form1()
			{
				InitializeComponent();
				POINT lpPoint;
				//Get current location of cursor
				GetCursorPos( out lpPoint );
				//Move to (0,0)
				SetCursorPos( 0, 0 );
				//Take screenshot
				//gfxScreenshot.CopyFromScreen(//...);
				MessageBox.Show("just for create a delay", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//Put back cursor
				SetCursorPos( lpPoint.X, lpPoint.Y );
			}
		}
	}
