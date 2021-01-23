    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    namespace CustomDrawingAndEvents
    {
	public partial class UserControl1 : UserControl
	{
		private struct MyLine
		{
			public Point mStart;
			public Point mEnd;
			public MyLine(Point xStart, Point xEnd)
			{
				mStart = xStart;
				mEnd = xEnd;
			}
		}
		private List<MyLine> mLines;
		private Point mCircleCenter;
		private Point mMousePosition;
		public UserControl1()
		{
			InitializeComponent();
			mLines = new List<MyLine>();
			
			//Double Buffer to prevent flicker
			DoubleBuffered = true;
			//Create the center for our circle. For this just put it in the center of 
			//the control.
			mCircleCenter = new Point(this.Width / 2, this.Height / 2);
		}
		private void UserControl1_MouseClick(object sender, MouseEventArgs e)
		{
			//User clicked create a new line to add to the list.
			mLines.Add(new MyLine(mCircleCenter, e.Location));
		}
		private void UserControl1_MouseMove(object sender, MouseEventArgs e)
		{
			//Update mouse position
			mMousePosition = e.Location;
			//Make the control redraw itself
			Invalidate();
		}
		private void UserControl1_Paint(object sender, PaintEventArgs e)
		{
			//Create the rect with 100 width/height (subtract half the diameter to center the rect over the circle)
			Rectangle lCenterRect = new Rectangle(mCircleCenter.X - 50, mCircleCenter.Y - 50, 100, 100);
			//Draw our circle in the center of the control with a diameter of 100 
			e.Graphics.DrawEllipse(new Pen(Brushes.Black), lCenterRect);
			//Draw all of our saved lines
			foreach (MyLine lLine in mLines) 
				e.Graphics.DrawLine(new Pen(Brushes.Red), lLine.mStart, lLine.mEnd);			
			//Draw our active line from the center of the circle to
			//our mouse location
			e.Graphics.DrawLine(new Pen(Brushes.Blue), mCircleCenter, mMousePosition);
		}
	}
}
