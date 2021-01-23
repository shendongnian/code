            button1.Tag = true;
            button1.Update();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            button1.Tag = false;
            button1.Update();
        }
        // there is no reason to re-draw it constantly, Paint event will be fired when needed
        private void button1_Paint(object sender, PaintEventArgs e)
        {
            // remember that all Tag's start as null
            if (((Control)sender).Tag != null && (bool)((Control)sender).Tag == true)
            {
                // and when needed just paint on control drawing area (also known as Canvas)
                e.Graphics.FillRectangle(Brushes.Red, 0, 0, 100, 100);
                e.Graphics.DrawString("Foo!", ((Control)sender).Font, Brushes.Beige, new PointF(5, 5));
            }
        }
