    Bitmap bmp = new Bitmap(pictureBox17.Width, pictureBox17.Height);
        private void draws()
        {
         if (bmp ==null)
         using (Graphics g = Graphics.FromImage(bmp))
                    {
                        //define area do pictureBox17 e preenche a branco
                        Brush brush = new SolidBrush(Color.White);
                        Rectangle area = new Rectangle(0, 0, pictureBox17.Width, pictureBox17.Height);
                        g.FillRectangle(brush, area);
                        //desenha as linhas do rectangulo
                        g.DrawLine(new Pen(Color.Black), esp, esp, esp, yWcorrigidoesp);
                     }
       else {
             using (Graphics g = Graphics.FromImage(bmp))
             {
                g.DrawLine(new Pen(Color.Black), esp, esp, esp, yWcorrigidoesp);
             }
        // some more lines
        }
         pictureBox17.Image = bmp;
        }
