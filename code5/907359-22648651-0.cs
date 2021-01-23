    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class ShapeButton : Button {
      public Action<PaintEventArgs> DoPaint { get; set; }
      protected override void OnPaint(PaintEventArgs e) {
        if (DoPaint != null) { DoPaint(e); }
      }
    }
    
    static class Program {
      static void Main() {
        // Ellipse button
        ShapeButton ellipseButton = new ShapeButton();
        ellipseButton.Location = new Point(10, 10);
        ellipseButton.Size = new Size(80, 80);
        ellipseButton.DoPaint = delegate(PaintEventArgs e) {
          Graphics graphics = e.Graphics;
          SolidBrush brush1 = new SolidBrush(SystemColors.ButtonFace);
          graphics.FillRectangle(brush1, 0, 0, ellipseButton.Width, ellipseButton.Height);
          SolidBrush brush2 = new SolidBrush(Color.Red);
          graphics.FillEllipse(brush2, 0, 0, ellipseButton.Width, ellipseButton.Height);
        };
        ellipseButton.Click += delegate(object sender, EventArgs e) {
          MessageBox.Show("Ellipse!");
        };
    
        // Triangle button
        ShapeButton triangleButton = new ShapeButton();
        triangleButton.Location = new Point(100, 10);
        triangleButton.Size = new Size(80, 80);
        triangleButton.DoPaint = delegate(PaintEventArgs e) {
          Graphics graphics = e.Graphics;
          SolidBrush brush1 = new SolidBrush(SystemColors.ButtonFace);
          graphics.FillRectangle(brush1, 0, 0, triangleButton.Width, triangleButton.Height);
          SolidBrush brush2 = new SolidBrush(Color.Green);
          Point[] points = { 
            new Point(triangleButton.Width / 2, 0), 
            new Point(0, triangleButton.Height), 
            new Point(triangleButton.Width, triangleButton.Height) 
          };
          graphics.FillPolygon(brush2, points);
        };
        triangleButton.Click += delegate(object sender, EventArgs e) {
          MessageBox.Show("Triangle!");
        };
        
        // Star button (using image)
        Button starButton = new Button();
        starButton.Location = new Point(190, 10);
        starButton.Size = new Size(80, 80);
        starButton.Image = new Bitmap("Star.png");
        starButton.Click += delegate(object sender, EventArgs e) {
          MessageBox.Show("Star!");
        };
    
        // The form
        Form form = new Form();
        form.Text = "Shape Button Test";
        form.ClientSize = new Size(280, 100);
        form.Controls.Add(ellipseButton);
        form.Controls.Add(triangleButton);
        form.Controls.Add(starButton);
        form.ShowDialog();
      }
    }
