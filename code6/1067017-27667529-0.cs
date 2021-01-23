            for (int x = 0; x < 20; x++)
            {
                System.Drawing.Graphics graphics = e.Graphics;
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(xpos - 10 - x / 2, ypos - 10 - x / 2, x, x);
                graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            }
