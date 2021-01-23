        struct Rect {
            public PointF p1 { get; set; }
            public PointF p2 { get; set; }
            public PointF p3 { get; set; }
            public PointF p4 { get; set; }
            public PointF p5 { get; set; }
        }
        void RectResize()
        {
            // input rectangle and sample vertices
            Rect input = new Rect();
            input.p1 = new PointF(80, 200);
            input.p2 = new PointF(160, 340);
            input.p3 = new PointF(470, 160);
            input.p4 = new PointF(390, 20);
            input.p5 = new PointF(80, 200);  // same as p1
            PointF[] r1 = { input.p1, input.p2, input.p3, input.p4 }; // conversion to array, easier to manipulate
            float ratio = .3F;  // inflation factor
            PointF center = new PointF(r1[0].X + (r1[2].X - r1[0].X) / 2, r1[0].Y + (r1[2].Y - r1[0].Y) / 2);
            PointF[] r2 = new PointF[4];  // output array
            for (int i = 0; i < 4; i++)
            {
                r2[i].X = center.X + (r1[i].X - center.X) * ratio;
                r2[i].Y = center.Y + (r1[i].Y - center.Y) * ratio;
            }
            // convert output to struct Rect if needed
            Rect output = new Rect();
            output.p1 = r2[0]; output.p2 = r2[1]; output.p3 = r2[2]; output.p4 = r2[3]; output.p5 = r2[0];
            // demo
            Graphics g = this.CreateGraphics();
            g.DrawPolygon(Pens.Blue, r1);
            g.DrawPolygon(Pens.Red, r2);
        }
