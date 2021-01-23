	private void DrawMap(PaintEventArgs e) {
		var pens = new[] { // TODO: draw layers instead
			new Pen(TrackColor),
			new Pen(SwitchColor),
			new Pen(RoadColor),
			new Pen(RiverColor),
			new Pen(CrossColor)
		};
		var b = Splines.Bounds;
		var g = e.Graphics;
		var f = true; // OutFull; // (TODO: limiting vectors to visible ones)
		var tr = GetTransformation(); // gets scale and translation for points
		float ts = tr[0], tx = tr[1], ty = tr[2];
		TrackSpline[] visible = !f ? Splines.GetSubset(ts, _Viewport) : null;
		var ct = f ? Splines.Count : visible.Length;
		for (int i = 0; i < ct; i++) {
			TrackSpline s = f ? Splines[i] : visible[i];
			var pen = pens[s.T];
			pen.Width = ts * s.W;
			if (ts < 0.01 || s.L) {
				var p1 = new PointF(s.A.X * ts + tx, s.A.Y * ts + ty);
				var p2 = new PointF(s.D.X * ts + tx, s.D.Y * ts + ty);
				g.DrawLine(pen, p1, p2);
			} else {
				var p1 = new PointF(s.A.X * ts + tx, s.A.Y * ts + ty);
				var p2 = new PointF(s.B.X * ts + tx, s.B.Y * ts + ty);
				var p3 = new PointF(s.C.X * ts + tx, s.C.Y * ts + ty);
				var p4 = new PointF(s.D.X * ts + tx, s.D.Y * ts + ty);
				var b1c = Math.Abs(p1.X - p2.X) >= 0.1f || Math.Abs(p1.Y - p2.Y) > 0.1f;
				var b2c = Math.Abs(p3.X - p4.X) >= 0.1f || Math.Abs(p3.Y - p4.Y) > 0.1f;
				if (b1c && b2c) g.DrawBezier(pen, p1, p2, p3, p4); else g.DrawLine(pen, p1, p4);
			}
		}
		foreach (var p in pens) p.Dispose();
	}
