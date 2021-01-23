        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var nodes = new[] { new Node { Code = 'A', Position = new Point(10, 10) }, new Node { Code = 'B', Position = new Point(45, 45) } };
            using (Pen P = new Pen(Color.LightBlue, 3))
            {
                P.StartCap = LineCap.NoAnchor;
                P.CustomEndCap = new AdjustableArrowCap(4, 8, false);
                for (int i = 0; i < nodes.Length; i++)
                {
                    var node = nodes[i];
                    for (int j = i; j < nodes.Length; j++)
                    {
                        var node2 = nodes[j];
                        if (node == node2)
                            continue;
                        Point startPoint = new Point(node.Position.X, node.Position.Y);
                        Point endPoint = new Point(node2.Position.X, node2.Position.Y);
                        pnlView.CreateGraphics().DrawLine(P, startPoint, endPoint);
                    }
                }
            }
            pnlView.PerformLayout();
        }
