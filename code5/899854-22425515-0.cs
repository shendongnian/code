    using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	namespace Stackoverflow
	{
		public partial class Print2DArrayForm : Form
		{
			public Print2DArrayForm()
			{
				InitializeComponent();
				//initial the matrix here
				matrix[0, 1] = true;
				matrix[1, 2] = true;
				matrix[1, 1] = true;
				matrix[1, 3] = true;
				matrix[2, 2] = true;
				this.Click += Draw2DArray;
			}
			bool[,] matrix = new bool[3, 4];
			private void Draw2DArray(object sender, EventArgs e)
			{
				int step = 50; //distance between the rows and columns
				int width = 40; //the width of the rectangle
				int height = 40; //the height of the rectangle
				using (Graphics g = this.CreateGraphics())
				{
					g.Clear(SystemColors.Control); //Clear the draw area
					using (Pen pen = new Pen(Color.Red, 2))
					{
						int rows = matrix.GetUpperBound(0) + 1 - matrix.GetLowerBound(0); // = 3, this value is not used
						int columns = matrix.GetUpperBound(1) + 1 - matrix.GetLowerBound(1); // = 4
						for (int index = 0; index < matrix.Length; index++)
						{
							int i = index / columns;
							int j = index % columns;
							if (matrix[i, j]) 
							{
								Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
								g.DrawRectangle(pen, rect);
								g.FillRectangle(System.Drawing.Brushes.Red, rect);
							}
						}
					}
				}
			}
		}
	}
