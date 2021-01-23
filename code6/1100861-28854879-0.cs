            Rectangle r1 = new Rectangle((int)(ecobdesenho / 10) / 2 + esp - 15, esp - 25, 25, 12);
            using (Matrix m = new Matrix())
            {  
                m.TranslateTransform((float)(xWcorrigido / 2 + esp), (float)(yWcorrigido / 2 + esp));
                m.RotateTransform(180);
                m.TranslateTransform((float)(-xWcorrigido / 2 - esp), (float)(-yWcorrigido / 2 - esp)); 
                m.RotateAt(180, new PointF((int)(ecobdesenho / 10) / 2 + esp - 15 + (25 / 2),
                                          esp - 25 + (12 / 2)));
                 g.Transform = m;
                 g.DrawRectangle(new Pen(Color.Black), r1);
                 g.DrawString("e/10", fnt2, new SolidBrush(Color.Black), (int)(ecobdesenho / 10) / 2 + esp - 15, esp - 25); //15 para tras, 15 para cima
                g.ResetTransform();
            }
