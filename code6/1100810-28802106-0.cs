    using (Matrix m = new Matrix())
    {
        m.RotateAt(angle, new PointF(r.Left + (r.Width / 2),
                                  r.Top + (r.Height / 2)));
        g.Transform = m;
        g.DrawString("e/10", fnt2, new SolidBrush(Color.Black), (int)(ecobdesenho / 10) / 2 + esp - 15, esp - 25); //15 para tras, 15 para cima
        g.DrawRectangle(Pens.Black, r);
        g.ResetTransform();
    }
