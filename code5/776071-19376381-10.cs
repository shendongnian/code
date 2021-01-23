            void zgcGrzgcGraph_MouseDoubleClick(object source, System.Windows.Forms.MouseEventArgs e)
        {
            if (Apprefs.graphSystem != null)
            {
                System.Drawing.PointF mousePt = new System.Drawing.PointF(e.X, e.Y);
                Apprefs.graphSystem.UCclicked(mousePt);
            }
        }
