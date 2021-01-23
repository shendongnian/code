	namespace WindowsFormsApplication2
	{
	public partial class Form1 : Form
	{
		public struct Line
		{
			public Point start;
			public Point end;
		}
		
		public Form1()
		{
			InitializeComponent();
		}
		Pen erasePen = new Pen(Color.White, 3.0F);
		Pen myPen = new Pen(Color.Red, 3.0F);
		Point p = new Point();
		Point endPoint = new Point();
		bool flag = false;
		List<WindowsFormsApplication2.Form1.Line> lines = new List<WindowsFormsApplication2.Form1.Line>();
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			flag = true;
			p = e.Location;
			endPoint = p;
		}
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (flag)
			{
				Graphics g = panel1.CreateGraphics();
				Point p2 = e.Location;
				EraseLine(p, endPoint, g);
				DrawAllLines(lines, g);
				
				DrawLine(p, p2, g);
				endPoint = p2;
				
				g.Dispose();
			}
		}
		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			// redraw for one last time...
			Graphics g = panel1.CreateGraphics();
			Point p2 = e.Location;
			
			lines.Add(new Line { start = p, end = p2} );
			EraseLine(p, endPoint, g);
			DrawAllLines(lines, g);
			
			flag = false;
			
			g.Dispose();
		}
		
		private void DrawLine(Point start, Point end, Graphics g)
		{
			g.DrawLine(myPen, start, end);
		}
		
		private void DrawLine(WindowsFormsApplication2.Form1.Line line, Graphics g)
		{
			g.DrawLine(myPen, line.start, line.end);
		}
		
		private void DrawAllLines(List<WindowsFormsApplication2.Form1.Line> allLines, Graphics g)
		{
			foreach(WindowsFormsApplication2.Form1.Line l in allLines)
			{
				g.DrawLine(myPen, l.start, l.end);
			}
		}
		
		private void EraseLine(Point start, Point end, Graphics g)
		{
			g.DrawLine(erasePen, start, end);
		}
	}}
